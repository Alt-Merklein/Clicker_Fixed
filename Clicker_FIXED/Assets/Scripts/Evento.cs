using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Evento
{
    [TextArea(3,10)]
    public string mensagem;
    public string remetente;
    public int consequenciaIndex;
}
