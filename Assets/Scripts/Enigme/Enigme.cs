using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enigme : MonoBehaviour {

    public List<Code> Code;

    private List<Code> _actualValidated;
    private List<LineRenderer> _lines;

	// Use this for initialization
	void Start () {
        _actualValidated = new List<Code>();
        _lines = new List<LineRenderer>();
        Event.Listen("code_activated", CodeValidate);
    }

    // Update is called once per frame
    void Update () {

    }

    void OnDrawGizmosSelected(Vector3 from, Vector3 target)
    {

            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(from, target);
    }

    void CodeValidate(params object[] args)
    {
        Code code = (Code)args[0];
        if (code == Code[_actualValidated.Count])
        {
            Debug.Log("Ajouté");
            _actualValidated.Add(code);
            code.Activate();

            if(_actualValidated.Count >= 2)
            {
                LineRenderer line = code.GetComponent<LineRenderer>();
                line.SetPosition(0, code.transform.position);
                line.SetPosition(1, Code[_actualValidated.Count - 2].transform.position);
                _lines.Add(line);
            }
        }
        else
        {
            Debug.Log("Echec");
            _actualValidated.ForEach(delegate(Code theCode)
            {
                theCode.Disactivate();
            });
            _lines.ForEach(delegate (LineRenderer line)
            {
                line.SetPosition(0, new Vector3(0,0,0));
                line.SetPosition(1, new Vector3(0,0,0));
            });
            _lines.Clear();
            _actualValidated.Clear();
        }
        if(_actualValidated.Count == Code.Count)
        {
            Debug.Log("Success");
            //_actualValidated.Clear();
        }
    }
}
