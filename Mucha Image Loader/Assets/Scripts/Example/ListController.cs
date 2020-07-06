using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mikabrytu.Mucha.Example
{
    public class ListController : MonoBehaviour
    {
        private string[] images = {
            "https://assets.pokemon.com/assets/cms2/img/pokedex/full/001.png",
            "https://assets.pokemon.com/assets/cms2/img/pokedex/full/002.png",
            "https://assets.pokemon.com/assets/cms2/img/pokedex/full/003.png",
            "https://assets.pokemon.com/assets/cms2/img/pokedex/full/004.png",
            "https://assets.pokemon.com/assets/cms2/img/pokedex/full/005.png",
            "https://assets.pokemon.com/assets/cms2/img/pokedex/full/006.png",
            "https://assets.pokemon.com/assets/cms2/img/pokedex/full/007.png",
            "https://assets.pokemon.com/assets/cms2/img/pokedex/full/008.png",
            "https://assets.pokemon.com/assets/cms2/img/pokedex/full/009.png"
        };

        [SerializeField] private GameObject imageItem;
        [SerializeField] private Transform content;

        private Mucha mucha;

        private void Start()
        {
            mucha = new Mucha();

            foreach (string image in images)
            {
                GameObject clone = Instantiate(imageItem, content);
                mucha.load(image).into(clone.GetComponent<RawImage>()).start();
            }
        }
    }
}
