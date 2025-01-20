using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioService : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioPlayer;
        [SerializeField] private List<AudioClass> _audios;

        public void PlayAudio(string audioName)
        {
            AudioClip clip = null;
            //перебери обьекты в списке
            foreach (AudioClass audio in _audios)
            {
                //если данный обьект равен имени аудио 
                if (audio.name == audioName)
                {
                    //пускай играет это аудио
                    _audioPlayer.clip = audio.clip;
                    _audioPlayer.Play();
                    break;

                }
                /*if (audio.loop == true)
                {
                    //пускай играет это аудио
                    _audioPlayer.clip = audio.clip;
                    _audioPlayer.Play();
                    yield return new WaitForSeconds(0f);

                }*/

            }
        }
       /* public IEnumerator ReturnPlayAudio(string audioName)
        {
            AudioClip clip = null;
            //перебери обьекты в списке
            foreach (AudioClass audio in _audios)
            {
                //если данный обьект равен имени аудио 
                if (audio.name == audioName)
                {
                    //пускай играет это аудио
                    _audioPlayer.clip = audio.clip;
                    _audioPlayer.Play();
                    break;
                }
                if (audio.loop == true)
                {
                    //пускай играет это аудио
                    _audioPlayer.clip = audio.clip;
                    _audioPlayer.Play();
                    yield return new WaitForSeconds(0f);

                }
            }
        }*/

        public void StopAudio(string audioName)
        {
            foreach (AudioClass audio in _audios)
            {
                //если данный обьект равен имени аудио 
                if (audio.name == audioName)
                {
                    //пускай stop это аудио
                    _audioPlayer.clip = audio.clip;
                    _audioPlayer.Stop();
                    break;

                }
                

            }
        }


    }
    [Serializable]
    public class AudioClass
    {
        public string name;
        public AudioClip clip;
        public bool loop;
    }
}