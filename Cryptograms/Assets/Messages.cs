using UnityEngine;

public class Messages : MonoBehaviour
{
    static string[] msgs =
    {
        "Coronavirus! I'm telling you, it's real.",
        "The sky is blue.",
        "The planet is fine. The people are fucked.",
        "Never go to bed mad. Stay up and fight.",
        "Accept who you are. Unless you're a serial killer.",
        "Don't be so humble - you are not that great.",
        "Never miss a good chance to shut up.",
        "I don't hate you.. I just don't like that you exist.",
        "Puns are the highest form of literature.",
        "A penny saved is a penny earned."
    };

    public static string RandomMessage()
    {
        int index = Random.Range(0, msgs.Length);
        return msgs[index];
    }
}
