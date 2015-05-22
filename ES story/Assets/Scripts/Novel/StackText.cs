using UnityEngine;
using System.Collections;

public class StackText {
	static public int MaxSize = 100;
	public int Size = 0;
	private struct Para { public string Author; public string Text; };
	private Para[] massive;

	public StackText()
	{
		massive = new Para[MaxSize];
	}

	public void AddString(string text, string author)
	{
		Para s;
		s.Text = text;
		s.Author = author;
		for (int i=Size-1; i>=0; i--)
			if (i!=MaxSize-1)
				massive[i+1] = massive[i];
		massive [0] = s;
		if (Size<MaxSize)
			Size++;
	}

	public string GetString(int i)
	{
		return massive[i].Text;
	}

	public string GetAuthor(int i)
	{
		return massive[i].Author;
	}
}
