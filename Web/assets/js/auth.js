import { getAuth, initializeAuth, createUserWithEmailAndPassword, signInWithEmailAndPassword, onAuthStateChanged, signOut } from "https://www.gstatic.com/firebasejs/9.5.0/firebase-auth.js";

const auth = getAuth();
const user = auth.currentUser;

var signInEmail = $("#in__email");
var signInPassword = $("#in__password");
var signUpEmail = $("#up__email");
var signUpName = $("#up__username");
var signUpPassword1 = $("#up__password--1");
var signUpPassword2 = $("#up__password--2");
var usernameList = [];

// If form input value is undefined, form label will still be visible
function formCheck(e) {
    if (e.value != "") {
        $(e).addClass("field__input--non-empty");
    } else {
        $(e).removeClass("field__input--non-empty");
    }
}

// Check if password value length is > 6
function lengthCheck(e) {
    if ((e.value.length < "6") && e.value.length > "0") {
        $(".field__error--first").css("display", "block");
    } else {
        $(".field__error--first").css("display", "none");
    }
}

// Check if password and confirmed password value are equal
function pwCheck() {
    if ((signUpPassword1.val() != signUpPassword2.val()) && (signUpPassword1.val().length >= "6") && (signUpPassword2.val().length > "0")) {
        $(".field__error--second").css("display", "block");
    } else {
        $(".field__error--second").css("display", "none");
    }
}

// Function for user to login
function userLogin() {
    // If sign in email and password input fields are empty, prevent user from submitting
    if (signInEmail.val() == "" || signInPassword.val() == "") {
        $(".form__error span").text("Please ensure email and password field is not empty");
        $(".form__error").css("display", "block");
    }
    else {
        signInWithEmailAndPassword(auth, signInEmail.val(), signInPassword.val())
        .then((userCredential) => {
            // Signed in
            var user = userCredential.user;
            location.href = "index.html";
        })
        .catch((error) => {
            var errorCode = error.code;
            var errorMessage = error.message;
            console.log(errorCode);

            $(".form__error span").text("The email or password you have entered is incorrect, or you do not have any exisiting account.");
            $(".form__error").css("display", "block");
        });
    }
}

// Function for user to create a new account
function userRegister(username) {
    createUserWithEmailAndPassword(auth, signUpEmail.val(), signUpPassword2.val()).then((userCredential)=>{
        createUserDatabase(email, username);

        //signedin
        const user = userCredential.user;
        console.log("created user ... " + userCredential);
        console.log("User is now signed in ");
    }).catch((error)=>{
        const errorCode = error.code;
        const errorMessage = error.message;
        console.log(`ErrorCode: ${errorCode} -> Message: ${errorMessage}`);
    });
}

// Function for user to logout
function userLogout() {
    signOut(auth).then(() => {
        // Sign-out successful.
    }).catch((error) => {
        // An error happened.
    });
}

// Check if user is signed in or not
onAuthStateChanged(auth, function (user) {
    if (user) {
        // User is signed in.
        $("#in").css("display", "none");
        $("#out").css("display", "initial");
    } else {
        // No user is signed in.
        $("#in").css("display", "inline-block");
        $("#out").css("display", "none");
    }
});

signInEmail.add(signInPassword).add(signUpEmail).add(signUpName).add(signUpPassword1).add(signUpPassword2).on("blur", function () {
    formCheck(this);
});

signUpPassword1.add(signInPassword).on("blur", function () {
    lengthCheck(this);
});

signUpPassword2.on("blur", function () {
    pwCheck();
});

$("#in__submit").click(function (e) {
    e.preventDefault();
    userLogin();
})

$("#up__submit").click(function (e) {
    e.preventDefault();
    userRegister(signUpName.val());
})

$("#out").on("click", function (e) {
    userLogout();
});

$("#page-back").click(function () {
    location.href = "index.html";
});