$("#Register").click(function () {
    location.href = '/Pages/LoginAndRegister/RegisterPage';
});
$("#signOut").click(function () {
    location.href = '/Pages/LoginAndRegister/SignOut';
});
$("#createTest").click(function () {
    location.href = '/Pages/Tests/TestCreation';
});
$("#YesAnswer").click(function () {
    let message = document.getElementById("YesAnswer").value;
    location.href = '/Pages/DeleteAward' + '/?Id=' + message;
});