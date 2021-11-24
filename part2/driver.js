var counter = 0;
var numPics = 0;
var sequentialID;
var randomID;
var numPics = document.getElementById("numPics");
var toggleButton = document.getElementById("toggleButton");
var previousButton = document.getElementById("previousButton");
var nextButton = document.getElementById("nextButton");
var playButton = document.getElementById("playButton");



document.getElementById("0").style.display = "inline-block";
document.getElementById("cap0").style.display = "inline-block";

sequentialLoop();

toggleButton.addEventListener("click", e => {
    if (toggleButton.innerHTML == "Random") {
        toggleButton.innerHTML = "Sequential";
        clearInterval(sequentialID);
        nextButton.style.display = "none";
        previousButton.style.display = "none";
        randomLoop();
    } else {
        toggleButton.innerHTML = "Random";
        clearInterval(randomID);
        nextButton.style.display = "inline";
        previousButton.style.display = "inline";
        sequentialLoop();
    }
})

playButton.addEventListener("click", e => {
    if (playButton.innerHTML == "Pause") {
        playButton.innerHTML = "Play";
        clearInterval(sequentialID);
        clearInterval(randomID);
    } else {
        playButton.innerHTML = "Pause";
        if (toggleButton.innerHTML == "Random") {
            sequentialLoop();
        } else {
            randomLoop();
        }
    }
})

nextButton.addEventListener("click", e => {
    document.getElementById(String(counter)).style.display = "none";
    document.getElementById("cap" + String(counter)).style.display = "none";
    counter++;
    try {
        document.getElementById(String(counter)).style.display = "inline-block";
        document.getElementById("cap" + String(counter)).style.display = "inline-block";
    }
    catch (err) {
        counter = 0;
        document.getElementById(String(counter)).style.display = "inline-block";
        document.getElementById("cap" + String(counter)).style.display = "inline-block";
    }
})

previousButton.addEventListener("click", e => {
    document.getElementById(String(counter)).style.display = "none";
    document.getElementById("cap" + String(counter)).style.display = "none";
    counter--;
    try {
        document.getElementById(String(counter)).style.display = "inline-block";
        document.getElementById("cap" + String(counter)).style.display = "inline-block";
    }
    catch (err) {
        counter = numPics.value;
        document.getElementById(String(counter)).style.display = "inline-block";
        document.getElementById("cap" + String(counter)).style.display = "inline-block";
    }
})




function sequentialLoop() {
    if (playButton.innerHTML == "Pause") {
        sequentialID = setInterval(function () {
            document.getElementById(String(counter)).style.display = "none";
            document.getElementById("cap" + String(counter)).style.display = "none";
            counter++;
            try {
                document.getElementById(String(counter)).style.display = "inline-block";
                document.getElementById("cap" + String(counter)).style.display = "inline-block";
            }
            catch (err) {
                counter = 0;
                document.getElementById(String(counter)).style.display = "inline-block";
                document.getElementById("cap" + String(counter)).style.display = "inline-block";
            }
            document.getElementById("messages").textContent = "W:" + document.getElementById(String(counter)).width + "H:" + document.getElementById(String(counter)).height;
        }, 5000)
    }
}

function randomLoop() {
    if (playButton.innerHTML == "Pause") {
        randomID = setInterval(function () {
            document.getElementById(String(counter)).style.display = "none";
            document.getElementById("cap" + String(counter)).style.display = "none";
            counter = Math.floor(Math.random() * parseInt(numPics.value));
            document.getElementById(String(counter)).style.display = "inline-block";
            document.getElementById("cap" + String(counter)).style.display = "inline-block";
        }, 5000)
    }
}
