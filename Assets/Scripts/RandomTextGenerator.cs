using UnityEngine;
public class RandomTextGenerator
{
    const string glyphs = "abcdefghijklmnopqrstuvwxyz";
    string wordGenerated = null;
    public string GenerateWord(int numberOfWords)
    {
        for(int i = 0; i < numberOfWords; i++)
        {
            int randomIndex = Random.Range(0, 26);
            wordGenerated += glyphs[randomIndex];
            Debug.Log(randomIndex + " " +  wordGenerated);
        }
        return wordGenerated;
        
    }
}
