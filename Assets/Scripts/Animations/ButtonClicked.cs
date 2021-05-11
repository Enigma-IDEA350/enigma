using UnityEngine;

public class ButtonClicked : MonoBehaviour
{
    private Animator _animator;
    private PlayButton _playButton;
    private GameLogic _gameLogic;
    private WireSocket _wireSocket;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _playButton = FindObjectOfType<PlayButton>();
        _gameLogic = FindObjectOfType<GameLogic>();
        _wireSocket = FindObjectOfType<WireSocket>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (_playButton != null)
        {
            if (_playButton.clicked == 1)
            {
                if (_gameLogic.CorrectDecode)
                {
                    _animator.Play("Base Layer.Move Wire");
                }
                if (!_gameLogic.CorrectDecode)
                {
                    _animator.SetBool("ButtonClicked", true);
                    _animator.Play("Base Layer.Move Wire 1");
                }
            }
        }
    }
}
