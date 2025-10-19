using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics.Geometry;
using UnityEngine;

namespace Chapter.Command
{
    public class Invoker : MonoBehaviour
    {
        bool _isRecording = false;
        bool _isReplaying = false;
        float _replayTime = 0f;
        float _recordingTime = 0f;
        SortedList<float, Command> _recordedCommands = new SortedList<float, Command>();

        public void ExecuteCommand(Command command)
        {
            command.Execute();
            
            if(_isRecording) _recordedCommands.Add(_recordingTime, command);
            
            Debug.Log($"Recorded Time : {_recordingTime}");
            Debug.Log($"Recorded Command : {command}");
        }

        public void Record()
        {
            _recordingTime = 0f;
            _isRecording = true;
        }

        public void Replay()
        {
            _replayTime = 0f;
            _isReplaying = true;

            if (_recordedCommands.Count <= 0)
            {
                Debug.Log("No commands to replay!");
                return;
            }
            
            _recordedCommands.Reverse();
        }

        void FixedUpdate()
        {
            if(_isRecording) _recordingTime += Time.fixedDeltaTime;

            if (_isReplaying)
            {
                _replayTime += Time.fixedDeltaTime;

                if (_recordedCommands.Any())
                {
                    if (Mathf.Approximately(_replayTime, _recordedCommands.Keys[0]))
                    {
                        Debug.Log($"Replay Time : {_replayTime}");
                        Debug.Log($"Replay Command : {_recordedCommands.First()}");
                        
                        _recordedCommands.Values[0].Execute();
                        _recordedCommands.RemoveAt(0);
                    }
                }
                else _isReplaying = false;
            }
        }
    }
}