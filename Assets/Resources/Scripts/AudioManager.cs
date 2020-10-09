using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Gestionnaire pour l'audio & les musiques à diffuser
/// </summary>
public class AudioManager : MonoBehaviour
{
    static private AudioManager _inst;
    static public AudioManager Inst
    {
        get { return _inst; }
    }


    private AudioSource _audioSource;
    public AudioSource audioSource
    {
        get { return _audioSource; }
    }


    // Booléen indiquant si un morceau se joue actuellement
    public bool isPlaying;

    // Liste des musiques, de type AudioClip
    private Object[] trackList;

    // Numéro de la piste jouée actuellement (index de la tracklist)
    private int trackNumber = 0;

    private void Awake()
    {
        _inst = this;
        _audioSource = GetComponent<AudioSource>();
        FillTrackList();
        SetMusic();
    }


    /// <summary>
    /// Fonction remplissant la source audio avec la piste passée en index par trackNumber
    /// </summary>
    public void SetMusic()
    {
        _audioSource.clip = (AudioClip)trackList[trackNumber];
    }


    /// <summary>
    /// Passage à la musique suivante
    /// </summary>
    public void NextMusic()
    {
        trackNumber++;
        if (trackNumber == trackList.Length) trackNumber = 0;
        SetMusic();
    }


    /// <summary>
    /// Retrait de la musique actuelle de la source audio
    /// </summary>
    public void RemoveMusic ()
    {
        _audioSource.clip = null;
    }
    

    /// <summary>
    /// Lancement de la musique actuelle
    /// </summary>
    public void PlayMusic ()
    {
        _audioSource.Play();
        isPlaying = true;
    }


    /// <summary>
    /// Pause de la musique actuelle
    /// </summary>
    public void PauseMusic ()
    {
        _audioSource.Pause();
    }


    /// <summary>
    /// Arrêt de la musique actuelle
    /// </summary>
    public void StopMusic ()
    {
        _audioSource.Stop();
        isPlaying = false;
    }


    /// <summary>
    /// Remplissage du tableau de musiques, avec les AudioClip du dossier musique
    /// </summary>
    public void FillTrackList ()
    {
        trackList = Resources.LoadAll("Sounds/Musics", typeof(AudioClip)); 
    }
}
