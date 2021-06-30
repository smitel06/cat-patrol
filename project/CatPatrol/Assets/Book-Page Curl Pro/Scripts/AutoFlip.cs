using UnityEngine;
using System.Collections;
using System;

namespace BookCurlPro
{
    [RequireComponent(typeof(BookPro))]
    public class AutoFlip : MonoBehaviour
    {
        public BookPro ControledBook;
        public FlipMode Mode;
        public float PageFlipTime = 1;
        public float DelayBeforeStart;
        public float TimeBetweenPages = 5;
        public bool AutoStartFlip = true;
        bool flippingStarted = false;
        bool isPageFlipping = false;
        float elapsedTime = 0;
        float nextPageCountDown = 0;
        bool isBookInteractable;
        // Use this for initialization
        //stuff for me
        public GameObject book;
        

        void Start()
        {
            if (!ControledBook)
                ControledBook = GetComponent<BookPro>();

            

        }

        private void OnEnable()
        {
            if (AutoStartFlip)
            {
                StartFlipping(1);
                AutoStartFlip = false;
            }
        }
        public void FlipRightPage()
        {
            if (isPageFlipping) return;
            if (ControledBook.CurrentPaper >= ControledBook.papers.Length) return;
            isPageFlipping = true;
            PageFlipper.FlipPage(ControledBook, PageFlipTime, FlipMode.RightToLeft, () => { isPageFlipping = false; });
        }
        public void FlipLeftPage()
        {
            if (isPageFlipping) return;
            if (ControledBook.CurrentPaper <= 0) return;
            isPageFlipping = true;
            PageFlipper.FlipPage(ControledBook, PageFlipTime, FlipMode.LeftToRight, () => { isPageFlipping = false; });
        }
        int targetPaper;
        public void StartFlipping(int target)
        {
            isBookInteractable = ControledBook.interactable;
            ControledBook.interactable = false;
            flippingStarted = true;
            elapsedTime = 0;
            nextPageCountDown = 0;
            targetPaper = target;
            if (target > ControledBook.CurrentPaper) Mode = FlipMode.RightToLeft;
            else if (target < ControledBook.currentPaper) Mode = FlipMode.LeftToRight;
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                //flip book back to start
                FlipLeftPage();
            }


                if (flippingStarted)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime > DelayBeforeStart)
                {
                    if (nextPageCountDown < 0)
                    {
                        if ((ControledBook.CurrentPaper < targetPaper &&
                            Mode == FlipMode.RightToLeft) ||
                            (ControledBook.CurrentPaper > targetPaper &&
                            Mode == FlipMode.LeftToRight))
                        {
                            isPageFlipping = true;
                            PageFlipper.FlipPage(ControledBook, PageFlipTime, Mode, () => { isPageFlipping = false; });
                        }
                        else
                        {
                            flippingStarted = false;
                            ControledBook.interactable = isBookInteractable;
                            this.enabled = false;

                        }

                        nextPageCountDown = PageFlipTime + TimeBetweenPages + Time.deltaTime;
                    }
                    nextPageCountDown -= Time.deltaTime;
                }
            }
        }
    }
}