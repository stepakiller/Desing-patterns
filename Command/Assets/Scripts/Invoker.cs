using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    [SerializeField] GameObject _prefabToSpawn;
    [SerializeField] Transform _playerCharacter;
    [SerializeField] int _maxHistorySize = 10;
    List<ICommand> _commandHistory = new List<ICommand>();
    Queue<(ICommand cmd, Vector2 pos)> _pendingBuffer = new Queue<(ICommand, Vector2)>();

    void Update() => HandleInput();

    void HandleInput()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) 
        {
            ICommand moveCmd = new Move(_playerCharacter);
            ExecuteCommand(moveCmd, mousePos, isBuffered: false);
        }

        if (Input.GetMouseButtonDown(1)) 
        {
            ICommand spawnCmd = new Spawn(_prefabToSpawn);
            ExecuteCommand(spawnCmd, mousePos, isBuffered: true);
        }

        if (Input.GetKeyDown(KeyCode.Return)) ProcessPendingQueue();
        if (Input.GetMouseButtonDown(2)) UndoLastCommand();
    }

    public void ExecuteCommand(ICommand command, Vector2 position, bool isBuffered)
    {
        if (isBuffered)
        {
            _pendingBuffer.Enqueue((command, position));
            Debug.Log("команда добавлена ​​в очередь выполнения");
        }
        else
        {
            command.Execute(position);
            AddToHistory(command);
        }
    }

    void ProcessPendingQueue()
    {
        while (_pendingBuffer.Count > 0)
        {
            var item = _pendingBuffer.Dequeue();
            item.cmd.Execute(item.pos);
            AddToHistory(item.cmd); 
        }
    }

    void AddToHistory(ICommand command)
    {
        _commandHistory.Add(command);
        if (_commandHistory.Count > _maxHistorySize) _commandHistory.RemoveAt(0);
    }

    public void UndoLastCommand()
    {
        if (_commandHistory.Count > 0)
        {
            int lastIndex = _commandHistory.Count - 1;
            ICommand lastCommand = _commandHistory[lastIndex];
            lastCommand.Undo();
            _commandHistory.RemoveAt(lastIndex);
        }
    }
}
