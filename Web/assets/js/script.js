// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries
// Import the functions you need from the SDKs you need
import { 
    getAuth, 
    initializeAuth, 
    createUserWithEmailAndPassword, 
    signInWithEmailAndPassword,
    onAuthStateChanged
} from "https://www.gstatic.com/firebasejs/9.5.0/firebase-auth.js";

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
const leaderboardRef = ref(db, "leaderboard");

//Working with Auth
const auth = getAuth();
const user = auth.currentUser;

var playerData = {
    email: "",
    username: "",
    leaderboardPosition: "N/A",
    totalGame: 0,
    totalScore: 0,
    highestScore: 0,
    averageAccuracy: 100
}

onAuthStateChanged(auth, (user) => {
    if (user) {
      // User is signed in, see docs for a list of available properties
      // https://firebase.google.com/docs/reference/js/firebase.User
      const uid = user.uid;
      console.log(user.email);
      // ...
    } else {
      // User is signed out
      // ...
    }
});

var leaderboardName = [];
var leaderboardScore = [];

// onValue(playerRef, (snapshot) => {
//     updateLeaderboard();
// });

onValue(leaderboardRef, (snapshot) => {
    updateLeaderboard();
});

//retrieve element from form
var formCreateUser = document.getElementById("frmCreateUser");
//we create a button listener to listen when someone clicks
//var readBtn = document.getElementById("submit").addEventListener("click", getPlayerData); incase
formCreateUser.addEventListener("submit", function(e){
    e.preventDefault();
    var email = document.getElementById("email").value;
    var username = $("#username").val();
    var password = document.getElementById("password").value;
    console.log("email" + email + "password" + password);
    createUser(email, username, password);
});

function retrieveLeaderboardData() {
    const que = query(playerRef, orderByChild("highestScore"));

    leaderboardName.length = 0; // Clears the array
    leaderboardScore.length = 0; // Clears the array

    get(que).then((snapshot) => {
        if (snapshot.exists()) {
            console.log(snapshot)
            let index = 1;

            snapshot.forEach((childSnapshot) => {
                
                leaderboardName.push(childSnapshot.child("username").val());
                leaderboardScore.push(childSnapshot.child("highestScore").val());
                console.log(`Name: ${childSnapshot.child("username").val()}, Highest Score: ${childSnapshot.child("highestScore").val()}`);
                index++;
            });

            console.log(leaderboardName);
            // leaderboardName.reverse();
            // leaderboardScore.reverse();
        }
    });
}

function updateLeaderboard(){
    retrieveLeaderboardData();
    
    setTimeout(() => {
        $("#leaderboard").empty(); // Clear leaderboard content first
        $(".leaderboard__list").empty(); // Clear leaderboard content first
        
        $("#leaderboard").append(`<tr>
            <th>Rank</th>
            <th>Points</th>
            <th>Username</th>
        </tr>`);

        // Appending header
        $(".leaderboard__list").append(`
            <li>
                <div class="leaderboard__list--content leaderboard__title--ranking">Ranking</div>
                <div class="leaderboard__list--content leaderboard__title--score">Score</div>
                <div class="leaderboard__list--content leaderboard__title--username">Username</div>
            </li>
        `);

        for (let i = 0; i < leaderboardName.length; i++) {
            $("#leaderboard").append(`<tr>
                <td>${i + 1}</td>
                <td>${leaderboardScore[leaderboardName.length - (i + 1)]}</td>
                <td>${leaderboardName[leaderboardName.length - (i + 1)]}</td>
            </tr>`);

            $(".leaderboard__list").append(`<li>
                <div class="leaderboard__list--content leaderboard--ranking">${i + 1}</div>
                <div class="leaderboard__list--content leaderboard--score">${leaderboardScore[leaderboardName.length - (i + 1)]}</div>
                <div class="leaderboard__list--content leaderboard--username">${leaderboardName[leaderboardName.length - (i + 1)]}</div>
            </li>`)
        }
    }, 100);
    
}

//create a new user based on email n password into Auth service
//user will get signed in
//userCredential is an object that gets
function createUser(email, username, password) {
    console.log("creating the user");
    createUserWithEmailAndPassword(auth, email, password).then((userCredential)=>{
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

function createUserDatabase(email, username) {
    const key = push(playerRef);
    // const key = db.child("players").push().key;
    playerData.email = email;
    playerData.username = username;

    set(key, playerData);
}