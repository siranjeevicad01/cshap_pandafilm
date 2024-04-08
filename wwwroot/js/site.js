// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// Home Page JavaScript code.
window.onscroll = function() {myFunction()};

var navbar_sticky = document.getElementById("navbar_sticky");
var sticky = navbar_sticky.offsetTop;
var navbar_height = document.querySelector('.navbar').offsetHeight;

function myFunction() {
  if (window.pageYOffset >= sticky + navbar_height) {
    navbar_sticky.classList.add("sticky")
	document.body.style.paddingTop = navbar_height + 'px';
  } else {
    navbar_sticky.classList.remove("sticky");
	document.body.style.paddingTop = '0'
  }
}



// NAV PAGE SELECTION //

// NOT USED YET ! ! !

/*const links = document.querySelectorAll('.nav_link');

links.forEach((link) => {
    link.addEventListener('click', (e) => {
        links.forEach((link) => {
            link.classList.remove('activeBtn');
        });
        e.preventDefault();
        link.classList.add('activeBtn');
    });
});
*/


// POP UP //

// const openSearchPopUp = document.querySelector('.search');
// const openLoginPopUp = document.querySelector('.profile_enter_btn');
// const closeSearchPopUp = document.querySelector('.search_pop_up_close');
// const closeLoginPopUp = document.querySelector('.login_pop_up_close');
// const seacrhPopUp = document.getElementById('searching_pop_up');
// const loginPopUp = document.getElementById('login_pop_up');

// openSearchPopUp.addEventListener('click', function (e) {
//     e.preventDefault();
//     seacrhPopUp.classList.add('active');
// })

// closeSearchPopUp.addEventListener('click', () => {
//     seacrhPopUp.classList.remove('active');
// })

// openLoginPopUp?.addEventListener('click', function (e) {
//     e.preventDefault();
//     loginPopUp.classList.add('active');
// })

// closeLoginPopUp?.addEventListener('click', () => {
//     loginPopUp.classList.remove('active');
// })

// // MOVIE SLIDERS //

// const movieCard = document.querySelectorAll('.movie_card');

// movieCard.forEach((movie) => {
//     const movieBody = movie.querySelector('.movie_body');
//     const movieImage = movie.querySelector('.movie_image');
//     movie.addEventListener('mouseover', (e) => {
//         movieBody.classList.add('visible');
//         movieImage.style.filter = 'blur(5px)';
//     });
//     movie.addEventListener('mouseout', (e) => {
//         movieBody.classList.remove('visible');
//         movieImage.style.filter = 'none';
//     });
// });

// // MOVIE BTNS //

// const watchLaterBtns = document.querySelectorAll('.watchLaterBtn');
// const addFavBtns = document.querySelectorAll('.addFavBtn');

// watchLaterBtns.forEach((watchLaterBtn) => {
//     watchLaterBtn.addEventListener('click', (e) => {
//         if (e.target.classList.contains('addToWatch')) {
//             e.target.classList.remove('addToWatch');
//         } else {
//             e.target.classList.add('addToWatch');
//         }
//     });
// });

// addFavBtns.forEach((addFavBtn) => {
//     addFavBtn.addEventListener('click', (e) => {
//         if (e.target.classList.contains('addToWatch')) {
//             e.target.classList.remove('addToWatch');
//         } else {
//             e.target.classList.add('addToWatch');
//         }
//     });
// });

// // CAROUSEL //

// const carousels = document.querySelectorAll('.movie_carousel');

// let isDragStart = false, prevPageX, prevScrollLeft;

// carousels.forEach((carousel) => {
//     carousel.addEventListener('mousedown', (e) => {
//         isDragStart = true;
//         prevPageX = e.pageX;
//         prevScrollLeft = carousel.scrollLeft;
//     });
//     carousel.addEventListener('mousemove', (e) => {
//         if (!isDragStart) return;
//         e.preventDefault();
//         let positionDiff = e.pageX - prevPageX;
//         carousel.scrollLeft = prevScrollLeft - positionDiff;
//     });
//     carousel.addEventListener('mouseup', () => {
//         isDragStart = false;
//     });
// });

// // VIDEOPLAYER SCRIPT //

// const videoContainer = document.querySelector(".video_container"),
//     mainVideo = videoContainer.querySelector("video"),
//     videoTimeline = videoContainer.querySelector(".video_timeline"),
//     progressBar = videoContainer.querySelector(".progress_bar"),
//     volumeBtn = videoContainer.querySelector(".volume i");
// volumeSlider = videoContainer.querySelector(".left input");
// currentVidTime = videoContainer.querySelector(".current_time"),
//     videoDuration = videoContainer.querySelector(".video_duration"),
//     playPauseBtn = videoContainer.querySelector(".play_pause i"),
//     skipBackward = videoContainer.querySelector(".skip_backward i"),
//     skipForward = videoContainer.querySelector(".skip_forward i")
// speedBtn = videoContainer.querySelector(".playback_speed i"),
//     speedOptions = videoContainer.querySelector(".speed_options"),
//     picInPicBtn = videoContainer.querySelector(".pic_in_pic i"),
//     fullScreenBtn = videoContainer.querySelector(".fullscreen i");

// const playIcon = 'bi-play-circle';
// const pauseIcon = 'bi-pause-circle';
// const volumeUp = 'bi-volume-up';
// const volumeMuted = 'bi-volume-mute';
// const makeFull = 'bi-fullscreen';
// const fullExit = 'bi-fullscreen-exit';

// let savedTimeCode = 0;

// const formatTime = time => {
//     let seconds = Math.floor(time % 60),
//         minutes = Math.floor(time / 60) % 60,
//         hours = Math.floor(time / 3600);

//     seconds = seconds < 10 ? `0${seconds}` : seconds;
//     minutes = minutes < 10 ? `0${minutes}` : minutes;
//     hours = hours < 10 ? `0${hours}` : hours;

//     if (minutes === 0 && hours === 0) {
//         return `${seconds}`;
//     } else if (hours === 0) {
//         return `${minutes}:${seconds}`;
//     }
//     return `${hours}:${minutes}:${seconds}`;
// };

// mainVideo.addEventListener("timeupdate", e => {
//     let { currentTime, duration } = e.target;
//     let percent = (currentTime / duration) * 100;
//     progressBar.style.width = `${percent}%`; // video progress bar change
//     currentVidTime.innerText = formatTime(currentTime); // video playtime display func
// });

// mainVideo.addEventListener("loadeddata", e => {
//     videoDuration.innerText = formatTime(e.target.duration);
// });

// videoTimeline.addEventListener("click", e => {
//     let timelineWidth = videoTimeline.clientWidth;
//     mainVideo.currentTime = (e.offsetX / timelineWidth) * mainVideo.duration; // video timeline func
// });

// volumeBtn.addEventListener("click", () => {
//     if (!volumeBtn.classList.contains(volumeUp)) {
//         mainVideo.volume = 0.5;
//         volumeBtn.classList.replace(volumeMuted, volumeUp); // turn on volume
//     } else {
//         mainVideo.volume = 0.0;
//         volumeBtn.classList.replace(volumeUp, volumeMuted); // mute volume
//     }
//     volumeSlider.value = mainVideo.volume;
// });

// volumeSlider.addEventListener("input", e => {
//     mainVideo.volume = e.target.value; // volume slider func
//     if (e.target.value == 0) {
//         volumeBtn.classList.replace(volumeUp, volumeMuted);
//     } else {
//         volumeBtn.classList.replace(volumeMuted, volumeUp);
//     }
// });

// speedBtn.addEventListener("click", () => {
//     speedOptions.classList.toggle("show"); // speedoptions show toggling
// });

// picInPicBtn.addEventListener("click", () => {
//     mainVideo.requestPictureInPicture(); // pic in pic button func
// });

// fullScreenBtn.addEventListener("click", () => {
//     videoContainer.classList.toggle("fullscreen");
//     if (document.fullscreenElement) {
//         fullScreenBtn.classList.replace(fullExit, makeFull);
//         return document.exitFullscreen(); // fullscreen exit func
//     }
//     fullScreenBtn.classList.replace(makeFull, fullExit);
//     videoContainer.requestFullscreen(); // fullscreen turning on func
// });

// skipBackward.addEventListener("click", () => {
//     mainVideo.currentTime -= 10; // skipping backward
// });

// skipForward.addEventListener("click", () => {
//     mainVideo.currentTime += 10; // skipping forward
// });

// mainVideo.addEventListener("click", () => {
//     mainVideo.paused ? mainVideo.play() : mainVideo.pause(); // play/pause on video click
// });

// playPauseBtn.addEventListener("click", () => {
//     if (mainVideo.paused) {
//         mainVideo.play();
//     } else {
//         mainVideo.pause();
//         savedTimeCode = currentVidTime.innerText;
//     }
//  // play/pause on button click
// });

// mainVideo.addEventListener("play", () => {
//     playPauseBtn.classList.replace(playIcon, pauseIcon); // play/pause icon play func
// });

// mainVideo.addEventListener("pause", () => {
//     playPauseBtn.classList.replace(pauseIcon, playIcon); // play/pause icon pause func
// });

// // CONTENT TIMECODE SAVING //

// function saveTimeCode(timeCode) {
//     fetch('/Content/SaveTimeCode', {
//         method: 'POST',
//         headers: {
//             'Content-Type': 'application/json',
//         },
//         body: JSON.stringify({ timeCode: timeCode }),
//     })
//         .then(response => response.json())
//         .then(data => {
//             console.log(data);
//         })
//         .catch(error => {
//             console.error('Error while sending data to server :', error);
//         });
// }

// window.addEventListener('beforeunload', () => {
//     if (videoPlayer.paused) {
//         saveTimeCode(savedTimeCode);
//     } else {
//         saveTimeCode(currentVidTime.innerText);
//     }
// });