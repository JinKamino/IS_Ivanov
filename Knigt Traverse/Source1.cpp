#include <iostream>
#include <vector>
#include <unordered_set>


using namespace std;

void print_board(const vector<vector<int>>& board)
{
    for (vector<int> row : board)
    {
        for (int cell : row)
        {
            if (cell > 9)
            {
                cout << cell << " ";
            }
            else {
                cout << cell << "  ";
            }
            
        }
        cout << endl;
    }
}

int BOARD_SIZE = 8;

const int dx[8] = { 2, 1, -1, -2, -2, -1, 1, 2 };
const int dy[8] = { 1, 2, 2, 1, -1, -2, -2, -1 };


struct Cell
{
    int x, y;
    bool operator==(const Cell& other) const
    {
        return x == other.x && y == other.y;
    }
};

struct CellHash
{
    size_t operator()(const Cell& cell) const
    {
        return cell.x * BOARD_SIZE + cell.y;
    }
};



bool dfs(Cell current, vector<Cell>& path, unordered_set<Cell, CellHash>& visited)
{
    if (path.size() == BOARD_SIZE * BOARD_SIZE)
    {
        return true;
    }
    for (int dx = -2; dx <= 2; dx++)
    {
        for (int dy = -2; dy <= 2; dy++)
        {
            if (abs(dx) + abs(dy) == 3)
            {
                Cell next = { current.x + dx, current.y + dy };
                if (next.x >= 0 && next.x < BOARD_SIZE && next.y >= 0 && next.y < BOARD_SIZE && !visited.count(next))
                {
                    path.push_back(next);
                    visited.insert(next);

                    if (dfs(next, path, visited))
                    {
                        return true;
                    }
                    path.pop_back();
                    visited.erase(next);
                }
            }
        }
    }
    return false;
}

vector<Cell> knightDFS(Cell start)
{
    vector<Cell> path = { start };
    unordered_set<Cell, CellHash> visited;
    visited.insert(start);

    if (dfs(start, path, visited))
    {
        return path;
    }
    return {};
}

int main()
{
    setlocale(LC_ALL, "");
    cout << "Введите начальную позицию по x для коня" << endl;
    int start_x;
    cin >> start_x;
    cout << "Введите начальную позицию по y для коня" << endl;
    int start_y;
    cin >> start_y;

    vector<Cell> answer{};
    if (start_x >= 0 && start_x < 8 && start_y >= 0 && start_y < 8)
    {
        answer = knightDFS({ start_x, start_y });
    }
    if (!answer.empty())
    {
        vector<vector<int>> res(BOARD_SIZE, vector<int>(BOARD_SIZE, 0));
        for (int i = 0; i < answer.size(); ++i)
        {
            res[answer[i].x][answer[i].y] = i;
        }
        print_board(res);
    }
    else
    {
        cout << "Нет решения" << endl;
    }
    
}