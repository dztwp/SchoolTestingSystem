
(function startTimer() {
    var duration = +document.getElementById("timer").innerHTML*60;
    var timer = duration, minutes, seconds;
    setInterval(function () {
        minutes = parseInt(timer / 60, 10);
        seconds = parseInt(timer % 60, 10);

        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        document.getElementById("timer").innerHTML = minutes + ":" + seconds;

        if (--timer == 0) {
            document.forms['executionForm'].submit();
            return;
        }
    }, 1000);
})();
