#include <iostream>
#include <string>
#include <vector>
#include <stdexcept>
#include <iomanip>
#include <queue>
#include <unordered_set>
#include <chrono> 
#include <stack>
#include <bitset>

using namespace std;
using namespace std::chrono;

constexpr int square(int x) {
    return x * x;
}

struct Move {
    int x;
    int y;
};

vector<Move> nextStateMoves = { {1,2}, {1,-2}, {-1,2}, {-1,-2}, {2,1}, {2,-1}, {-2,1}, {-2,-1} };

template <size_t Size>
class KnightTour {
public:
    bitset<square(Size)> data;
    int knightPos;
    int notVisited;
    int heuristic;

    KnightTour(int position) {
        if (position > square(Size) - 1) {
            throw invalid_argument("Received wrong pos");
        }
        knightPos = position;
        data[position] = true;
        notVisited = square(Size) - 1;

        heuristic = heuristicFunction();
    }

    inline int heuristicFunction() {
        int res = 0;

        for (const auto move : nextStateMoves) {
            int curX = move.x + knightPos % Size;
            int curY = move.y + knightPos / Size;

            int newPos = knightPos + move.x + move.y * Size;

            if (curX < 0 || curX >= Size || curY < 0 || curY >= Size || data[newPos]) continue;

            res++;
        }

        return res;
    }

    KnightTour(const KnightTour& other) {
        data = bitset<square(Size)>(other.data);

        knightPos = other.knightPos;
        notVisited = other.notVisited;
        heuristic = other.heuristic;
    }

    KnightTour() {
        knightPos = 0;
        notVisited = square(Size);
        heuristic = 0;
    }

    bool operator==(const KnightTour& other) const {
        return data == other.data;
    }

    inline int getMoves() const {
        return square(Size) - 1 - notVisited;
    }
};

template <size_t Size>
struct State {
    KnightTour<Size> knightTour;
    const State<Size>* parent;

    State() : knightTour(), parent(nullptr) {}
};

template <size_t Size>
inline State<Size>* moveState(const State<Size>& currentState, Move move) {

    int curX = move.x + currentState.knightTour.knightPos % Size;
    int curY = move.y + currentState.knightTour.knightPos / Size;

    int newPos = currentState.knightTour.knightPos + move.x + move.y * Size;

    if (curX < 0 || curX >= Size || curY < 0 || curY >= Size || currentState.knightTour.data[newPos]) return nullptr;

    auto newState = new State<Size>(currentState);
    newState->parent = &currentState;
    newState->knightTour.notVisited--;
    newState->knightTour.knightPos = newPos;
    newState->knightTour.data[newPos] = true;
    newState->knightTour.heuristic = newState->knightTour.heuristicFunction();

    return newState;
}

template <size_t Size>
State<Size>* bfs(const KnightTour<Size>& startGame) {
    queue<State<Size>*> q;
    unordered_set<bitset<square(Size)>> visited;
    visited.insert(startGame.data);

    auto initialState = new State<Size>();
    initialState->knightTour = startGame;

    q.push(initialState);

    while (!q.empty()) {
        auto currentState = q.front();
        q.pop();

        if (currentState->knightTour.notVisited == 0) {
            return currentState;
        }

        for (const auto move : nextStateMoves) {
            auto nextState = moveState(*currentState, move);

            if (nextState) {
                auto hash = nextState->knightTour.data;

                if (visited.find(hash) == visited.end()) {
                    visited.insert(hash);
                    q.push(nextState);
                }
                else {
                    delete nextState;
                }
            }
        }
    }

    return nullptr;
}

template <size_t Size>
State<Size>* dfs(const KnightTour<Size>& startGame) {
    stack<State<Size>*> s;
    unordered_set<bitset<square(Size)>> visited;
    visited.insert(startGame.data);

    auto initialState = new State<Size>();
    initialState->knightTour = startGame;

    s.push(initialState);

    while (!s.empty()) {
        auto currentState = s.top();
        s.pop();

        if (currentState->knightTour.notVisited == 0) {
            return currentState;
        }

        for (const auto move : nextStateMoves) {
            auto nextState = moveState(*currentState, move);

            if (nextState) {
                auto hash = nextState->knightTour.data;

                if (visited.find(hash) == visited.end()) {
                    visited.insert(hash);
                    s.push(nextState);
                }
                else {
                    delete nextState;
                }
            }
        }
    }

    return nullptr;
}

template <size_t Size>
State<Size>* ids(const KnightTour<Size>& startGame) {
    for (int maxDepth = 0;; maxDepth++) {
        stack<State<Size>*> s;

        auto initialState = new State<Size>();
        initialState->knightTour = startGame;

        s.push(initialState);

        while (!s.empty()) {
            auto currentState = s.top();
            s.pop();

            if (currentState->knightTour.notVisited == 0) {
                return currentState;
            }

            if (currentState->knightTour.getMoves() < maxDepth)
                for (const auto move : nextStateMoves) {
                    auto nextState = moveState(*currentState, move);

                    if (nextState) {
                        if (currentState->parent && nextState->knightTour == currentState->parent->knightTour)
                        {
                            delete nextState;
                            continue;
                        }
                        s.push(nextState);
                    }
                }
        }
    }

    return nullptr;
}

template <size_t Size>
struct StatePtrComparator {
    bool operator()(const State<Size>* lst, const State<Size>* rst) const {
        return (lst->knightTour.heuristic + lst->knightTour.notVisited * 9) > (rst->knightTour.heuristic + rst->knightTour.notVisited * 9);
    }
};

template <size_t Size>
State<Size>* aStar(const KnightTour<Size>& startGame) {
    priority_queue<State<Size>*, vector<State<Size>*>, StatePtrComparator<Size>> pq;
    unordered_set<bitset<square(Size)>> visited;
    visited.insert(startGame.data);

    auto initialState = new State<Size>();
    initialState->knightTour = startGame;

    pq.push(initialState);

    while (!pq.empty()) {
        auto currentState = pq.top();
        pq.pop();

        if (currentState->knightTour.notVisited == 0) {
            return currentState;
        }

        for (const auto move : nextStateMoves) {
            auto nextState = moveState(*currentState, move);

            if (nextState) {
                auto hash = nextState->knightTour.data;

                if (visited.find(hash) == visited.end()) {
                    visited.insert(hash);
                    pq.push(nextState);
                }
                else {
                    delete nextState;
                }
            }
        }
    }

    return nullptr;
}

template <size_t Size>
constexpr int getPos(int size, int dx, int dy) {
    return dx + dy * size;
}

template <size_t Size>
std::vector<std::string> makeResult(const State<Size>& st) {
    std::vector<std::string> res;
    State<Size> state = st;

    while (state.parent != nullptr) {
        auto parent = *state.parent;
        res.push_back(to_string((int)state.knightTour.knightPos));

        state = parent;
    }
    return res;
}

template <size_t Size>
void showResults(int startPos, State<Size>* (*func)(const KnightTour<Size>&), bool showPath) {
    KnightTour<Size> game(startPos);

    auto start = high_resolution_clock::now();

    auto res = func(game);

    auto stop = high_resolution_clock::now();

    auto duration = duration_cast<microseconds>(stop - start);

    if (res && res->knightTour.getMoves() > 0) {
        cout << "start pos: " << (int)startPos << " solution had found, exec time: " << duration.count() / 1000.0 << " ms." << endl;
        auto vec = makeResult(*res);
        if (showPath) {
            cout << (int)startPos;
            for (int i = vec.size() - 1; i >= 0; i--)
                cout << " -> " << vec[i];

            if (vec.size() != 0) cout << endl;
        }

        cout << endl;
    }
    else
    {
        cout << "start pos: " << (int)startPos << " solution had not found." << endl << endl;
    }
}

int main() {
    setlocale(LC_ALL, "");

    constexpr int size = 8;

    auto testPos = { 0 };
    //cout << "=============================\t BFS" << endl << endl;
    //for (auto s = testPos.begin(); s != testPos.end(); s++)
    //    showResults<size>(*s, bfs, true);
    //cout << "=============================\t DFS" << endl << endl;
    //for (auto s = testPos.begin(); s != testPos.end(); s++)
    //    showResults<size>(*s, dfs, true);
    //cout << "=============================\t IDS" << endl << endl;
    //for (auto s = testPos.begin(); s != testPos.end(); s++)
    //    showResults<size>(*s, ids, true);
    cout << "=============================\t A*" << endl << endl;
    for (auto s = testPos.begin(); s != testPos.end(); s++)
        showResults<size>(*s, aStar, true);
}