// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries
// Import the functions you need from the SDKs you need
import { getAuth, initializeAuth, createUserWithEmailAndPassword, signInWithEmailAndPassword } from "https://www.gstatic.com/firebasejs/9.5.0/firebase-auth.js";
import { getDatabase, ref, child, push, get, set, onValue, orderByChild, orderByKey, query } from "https://www.gstatic.com/firebasejs/9.5.0/firebase-database.js";

const db = getDatabase();
const playerRef = ref(db, "players");

//Working with Auth
const auth = getAuth();

var playerData = {
    email: "",
    username: "",
    leaderboardPosition: "N/A",
    totalGame: 0,
    totalScore: 0,
    highestScore: 0,
    averageAccuracy: 100
}

var leaderboardName = [];
var leaderboardScore = [];

onValue(playerRef, (snapshot) => {
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

    get(que).then((snapshot) => {
        if (snapshot.exists()) {
            snapshot.forEach((childSnapshot) => {
                console.log("hi");
                leaderboardName.push(childSnapshot.child("username").val());
                leaderboardScore.push(childSnapshot.child("highestScore").val());
                console.log(`Name: ${childSnapshot.child("username").val()}, Highest Score: ${childSnapshot.child("highestScore").val()}`);
            });

            console.log(leaderboardName);
            // leaderboardName.reverse();
            // leaderboardScore.reverse();
        }
    });
}

function updateLeaderboard(){
    retrieveLeaderboardData();
    // await retrieveLeaderboardData();
    // retrieveLeaderboardData().then(console.log);

    // get(playerRef).then((snapshot) => {//retrieve a snapshot of the data using a callback\
    //     console.log(snapshot);
    //     if (snapshot.exists()) {//if the data exist
    //         console.log("yes");
    //         try {
    //             $("#leaderboard").empty(); // Clear leaderboard content first
    //             $("#leaderboard").append(`<tr>
    //                 <th>Rank</th>
    //                 <th>Points</th>
    //                 <th>Username</th>
    //             </tr>`);

    //             snapshot.forEach((childSnapshot) => {//looping through each snapshot
    //                 //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/forEach

    //                 console.log("GetPlayerData: childkey " + childSnapshot.key);

    //                 $("#leaderboard").append(`<tr>
    //                     <td>${childSnapshot.child("username").val()}</td>
    //                     <td>${childSnapshot.child("highestScore").val()}</td>
    //                     <td>${childSnapshot.child("username").val()}</td>
    //                 </tr>`);
    //             });
    //         } catch(error) {
    //             console.log("Error getPlayerData" + error);
    //         }
    //     }
    // });

    setTimeout(() => {
        $("#leaderboard").empty(); // Clear leaderboard content first
        $(".leaderboard-list").empty();
        
        $("#leaderboard").append(`<tr>
            <th>Rank</th>
            <th>Points</th>
            <th>Username</th>
        </tr>`);

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