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
        "I don't hate you... I just don't like that you exist.",
        "Puns are the highest form of literature.",
        "A penny saved is a penny earned.",
        "You can totally do this.",
        "Stay foolish to stay sane.",
        "When nothing goes right, go left.",
        "Try Again. Fail again. Fail better.",
        "Impossible is for the unwilling.",
        "I can and I will.",
        "He who is brave is free.",
        "Prove them wrong.",
        "My life is my message.",
        "Screw it, let’s do it.",
        "Boldness be my friend.",
        "Keep going. Be all in.",
        "My life is my argument.",
        "Leave no stone unturned.",
        "Stay hungry. Stay foolish.",
        "Broken crayons still color.",
        "And so the adventure begins.",
        "If you want it, work for it.",
        "You can if you think you can.",
        "Whatever you are, be a good one.",
        "Grow through what you go through.",
        "Do it with passion or not at all.",
        "The past does not equal the future.",
        "Success is the child of audacity.",
        "Dream without fear.",
        "Love without limits.",
        "You matter.",
        "Open your mind.",
        "Get up off the couch.",
        "Fall seven times, stand up eight.",
        "Live the moment.",
        "Be in the now.",
        "Take it easy.",
        "Never stop dreaming.",
        "Follow your heart.",
        "Keep your chin up.",
        "Now is all you have.",
        "Keep moving forward.",
        "Nothing lasts forever.",
        "Work hard. Stay humble.",
        "Enjoy the little things.",
        "Feel the fear and do it anyway.",
        "Collect moments – not things.",
        "Be a voice. Not an echo.",
        "Silence is an answer too.",
        "Time is the soul of this world.",
        "Life is short, death is forever.",
        "Pain is inevitable. Suffering is optional.",
        "Don’t raise your voice. Improve your argument.",
        "Love the life you live."
    };

    public static string RandomMessage()
    {
        int index = Random.Range(0, msgs.Length);
        return msgs[index];
    }
}
