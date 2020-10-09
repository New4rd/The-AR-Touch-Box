using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject musicInterface;
    public GameObject creditInterface;


    /// <summary>
    /// Activation / désactivation de l'interface de crédits
    /// </summary>
    public void SwitchCreditInterface ()
    {
        creditInterface.SetActive(!creditInterface.activeSelf);
    }


    /// <summary>
    /// Activation du bouton central sur la scène de bienvenue. Accès à la scène AR
    /// </summary>
    public void WelcomeButton ()
    {
        SceneManager.UnloadSceneAsync("WelcomeScene");
        //yield return new WaitUntil(() => ScenesManager.Inst.operationDone);
        SceneManager.LoadSceneAsync("ARScene", LoadSceneMode.Additive);
    }



    /// <summary>
    /// Activation / désactivation de l'interface des contrôles musicaux
    /// </summary>
    public void SwitchMusicInterface ()
    {
        musicInterface.SetActive(!musicInterface.activeSelf);
    }


    /// <summary>
    /// Activation du bouton Play, lecture/pause de la musique en cours
    /// </summary>
    public void PlayButton ()
    {
        if (AudioManager.Inst.audioSource.isPlaying)
        {
            AudioManager.Inst.PauseMusic();
        }
        else
        {
            AudioManager.Inst.PlayMusic();
        }
    }


    /// <summary>
    /// Activation du bouton Next, passage à la piste suivante
    /// </summary>
    public void NextTrackButton ()
    {
        AudioManager.Inst.NextMusic();
        AudioManager.Inst.PlayMusic();
    }


    /// <summary>
    /// Réinitialisation des objets retirés par l'utilisateur
    /// </summary>
    public void ResetDisappearedObjects ()
    {
        foreach (GameObject obj in RingOfObjects.Inst.listRing)
        {
            obj.SetActive(true);
        }
    }
}
