/* 
    Firebase Auth Imports
*/
import { 
    getAuth, 
    initializeAuth, 
    createUserWithEmailAndPassword, 
    signInWithEmailAndPassword, 
    onAuthStateChanged, signOut, 
    setPersistence, 
    browserLocalPersistence,
    updateProfile,
    sendPasswordResetEmail
} from "https://www.gstatic.com/firebasejs/9.5.0/firebase-auth.js";

/* 
    Firebase Database Imports
*/
import { 
    getDatabase, 
    ref,
    child, 
    push, 
    get, 
    set, 
    onValue, 
    orderByChild, 
    orderByKey, 
    query 
} from "https://www.gstatic.com/firebasejs/9.5.0/firebase-database.js";

const db = getDatabase();
const playerRef = ref(db, "players");

const auth = getAuth();
const user = auth.currentUser;

var signInEmail = $("#in__email");
var signInPassword = $("#in__password");

var signUpEmail = $("#up__email");
var signUpName = $("#up__username");
var signUpPassword1 = $("#up__password--1");
var signUpPassword2 = $("#up__password--2");

var recoveryEmail = $("#recovery__email");

var usernameList = [];

var isUsernameSimilar = false;

var playerData = {
    email: "",
    username: "",
    leaderboardPosition: "N/A",
    totalGame: 0,
    totalScore: 0,
    highestScore: 0,
    averageAccuracy: 100
}

// Check if user is signed in or not
onAuthStateChanged(auth, (user) => {
    if (user) {
        // User is signed in.
        $("#in").css("display", "none");
        $("#out").css("display", "initial");
        $("#username").css("display", "initial");
        $("#username").text(user.displayName);
        
        console.log(user.displayName);
    } else {
        // No user is signed in.
        $("#in").css("display", "inline-block");
        $("#out").css("display", "none");
        $("#username").css("display", "none");

        console.log("Not signed in");
    }
});

// If form input value is undefined, form label will still be visible
function formCheck(e) {
    if (e.value != "") {
        $(e).addClass("field__input--non-empty");
    } else {
        $(e).removeClass("field__input--non-empty");
    }
}

function signInFormCheck() {
    if (signInEmail.val() == "" || signInPassword.val() == "") {
        $("#in__submit").prop("disabled", true);
    }
    else if ((signInPassword.val().length > "0" && signInPassword.val().length < "6")) {
        $("#in__submit").prop("disabled", true);
        $(".field__error--first").css("display", "block");
    }
    else {
        $("#in__submit").prop("disabled", false);
        $(".field__error--first").css("display", "none");
    }
}

function signUpFormCheck() {
    if (signUpEmail.val() == "" || signUpName.val() == "" || signUpPassword1.val() == "" || signUpPassword2.val() == "") {
        $("#up__submit").prop("disabled", true);
    }
    else if ((signUpPassword1.val() != signUpPassword2.val()) && (signUpPassword1.val().length >= "6") && (signUpPassword2.val().length > "0")) {
        $("#up__submit").prop("disabled", true);
        $(".field__error--second").css("display", "block");
    }
    else if ((signUpPassword1.val().length > "0" && signUpPassword1.val().length < "6")) {
        $("#up__submit").prop("disabled", true);
        $(".field__error--first").css("display", "block");
    }
    else {
        console.log("hi");
        $("#up__submit").prop("disabled", false);
        $(".field__error--first").css("display", "none");
        $(".field__error--second").css("display", "none");
    }
}

function recoveryFormCheck() {
    if (recoveryEmail.val() == "") {
        $("#recovery__submit").prop("disabled", true);
    }
    else {
        $("#recovery__submit").prop("disabled", false);
    }
}

// Function for user to login
function userLogin() {
    setPersistence(auth, browserLocalPersistence)
    .then(() => {
        return signInWithEmailAndPassword(auth, signInEmail.val(), signInPassword.val())
        .then((userCredential) => {
            // Signed in
            var user = userCredential.user;
            location.href = "index.html";
        })
        .catch((error) => {
            var errorCode = error.code;
            var errorMessage = error.message;
            console.log(errorCode);

            $(".form__error span").text("The email or password you have entered is incorrect, or the account does not exist");
            $(".form__error").css("display", "block");
        });;
    })
    .catch((error) => {
        // Handle Errors here.
        const errorCode = error.code;
        const errorMessage = error.message;
    });
}

// Function for user to create a new account
function userRegister(username) {
    compareUsername(username);
    
    setTimeout(() => {
        console.log(isUsernameSimilar);
        if (isUsernameSimilar) {
            $(".form__error span").text("The account with the email or username already exist");
            $(".form__error").css("display", "block");
        }
        else {
            createUserWithEmailAndPassword(auth, signUpEmail.val(), signUpPassword2.val())
            .then((userCredential) => {
                createUserDatabase(signUpEmail.val(), username);
        
                //signedin
                const user = userCredential.user;
                console.log("created user ... " + userCredential);
                console.log("User is now signed in ");
        
                // Set the user's displayName in Authenticator based on the username parameter
                updateProfile(user, {
                    displayName: username
                }).then(() => {
                    console.log("Display name set successfully!");
                    // location.href = "index.html";
                }).catch((error) => {
                    const errorCode = error.code;
                    const errorMessage = error.message;
                    console.log(`ErrorCode: ${errorCode} -> Message: ${errorMessage}`);
                })
            }).catch((error) => {
                const errorCode = error.code;
                const errorMessage = error.message;
                console.log(`ErrorCode: ${errorCode} -> Message: ${errorMessage}`);
                $(".form__error span").text("An account with the email or username already exist");
                $(".form__error").css("display", "block");
            });
        }
    }, 500);
}

// Function for user to logout
function userLogout() {
    signOut(auth).then(() => {
        // Sign-out successful.
    }).catch((error) => {
        // An error happened.
    });
}


// Function for user password recovery email
function userRecovery(email) {
    sendPasswordResetEmail(auth, email)
    .then(() => {
        console.log("Password Reset Email Sent Successfully!");
        $("#recovery-form").css("display", "none");
        $("#recovery-success").css("display", "flex");
    })
    .catch((error) => {
        const errorCode = error.code;
        const errorMessage = error.message;
        console.log("User Recovery" + errorMessage);
    })
}

// Create a new set of data in the database for newly registered users
function createUserDatabase(email, username) {
    const key = push(playerRef);
    // const key = db.child("players").push().key;
    playerData.email = email;
    playerData.username = username;

    set(key, playerData);
}

function compareUsername(username) {
    get(playerRef).then((snapshot) => {
        if (snapshot.exists()) {
            try {
                snapshot.forEach((childSnapshot) => {
                    if (!isUsernameSimilar) {
                        if (username == childSnapshot.child("username").val()) {
                            console.log("same");
    
                            isUsernameSimilar = true;
                            return;
                        }
                        else {
                            isUsernameSimilar = false;
                        }
                    }
                });
            }
            catch(error) {
                console.log("Error compareUsername" + error);
            }
        }
    });
}

// On blur with these IDs, run the formCheck() function
signInEmail
.add(signInPassword)
.add(signUpEmail)
.add(signUpName)
.add(signUpPassword1)
.add(signUpPassword2)
.add(recoveryEmail).on("blur", function () {
    formCheck(this);
});

// On blur with these IDs, run the signInFormCheck() function
signInEmail
.add(signInPassword).on("blur", function() {
    signInFormCheck();
});

// On blur with these IDs, run the signUpFormCheck() function
signUpEmail
.add(signUpName)
.add(signUpPassword1)
.add(signUpPassword2).on("blur", function () {
    signUpFormCheck();
});

// On blur with these IDs, run the recoveryFormCheck() function
recoveryEmail.on("blur", function () {
    recoveryFormCheck();
});

$("#in__submit").click(function (e) {
    e.preventDefault();
    userLogin();
})

$("#up__submit").click(function (e) {
    e.preventDefault();
    userRegister(signUpName.val());
})

$("#recovery__submit").click(function (e) {
    e.preventDefault();
    userRecovery(recoveryEmail.val());
})

$("#out").on("click", function (e) {
    userLogout();
});

$("#page-back").click(function () {
    location.href = "index.html";
});