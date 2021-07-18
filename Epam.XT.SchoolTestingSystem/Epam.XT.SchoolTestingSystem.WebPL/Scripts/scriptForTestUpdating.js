
(function GetRightAnswer() {
    var numberOfQuestion = +document.getElementById("numberOfQuestion").value;
    var rightAnswer = +document.getElementById("Radios" + numberOfQuestion).value;
    
    for (var i = 1; i < 5; i++) {
        var variant = +document.getElementById("Radios" + numberOfQuestion + i).value;
        if (variant == rightAnswer) {
            var commandString = 'input[name="exampleRadios' + numberOfQuestion + '"][value="' + i + '"]';
            $(commandString).prop("checked",true);
            return;
        }
    }
})();