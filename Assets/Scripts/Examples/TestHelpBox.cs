using UnityEngine;

public class TestHelpBox : MonoBehaviour
{
	[HelpBox(
		"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum et lorem porttitor, pulvinar dui ac, gravida dolor. Mauris congue tempus tellus, non viverra lacus. Nunc porttitor nunc dui, in vulputate dolor hendrerit dictum. Sed rutrum congue fermentum. Donec mattis mattis nisl, ut dictum mauris tristique eu. In auctor lectus magna, tempus lacinia magna aliquam iaculis. Nullam aliquet nisi nibh, sit amet auctor ligula laoreet vitae.")]
	public float a;

	[HelpBox("text", HelpBoxMessageType.Warning)]
	public float b;

	[HelpBox("text", HelpBoxMessageType.Info)]
	public float c;

	[HelpBox("text", HelpBoxMessageType.Error)]
	public float d;
}