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
    update,
    get, 
    set, 
    onValue, 
    orderByChild, 
    orderByKey, 
    query,
    remove
} from "https://www.gstatic.com/firebasejs/9.5.0/firebase-database.js";

const db = getDatabase();
const playerRef = ref(db, "players");
const leaderboardRef = ref(db, "leaderboard");

//Working with Auth
const auth = getAuth();
const user = auth.currentUser;

var leaderboardData = {
    username: "",
    highestScore: 0
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

// onValue(playerRef, () => {
//     updateLeaderboard();
// });

leaderboardUpdater();

// Updates leaderboard every 10 seconds
// Credits: https://stackoverflow.com/questions/7188145/call-a-javascript-function-every-5-seconds-continuously
function leaderboardUpdater() {
    updateLeaderboard();

    setInterval(function() {
        updateLeaderboard();
    }, 10000); // Every 1000 is 1 second
}

function retrieveLeaderboardData() {
    const que = query(playerRef, orderByChild("highestScore"));

    get(que).then((snapshot) => {
        if (snapshot.exists()) {
            console.log(snapshot.size)
            remove(leaderboardRef); // Delete current leaderboard data in Database

            let index = snapshot.size;
            let position;

            snapshot.forEach((childSnapshot) => {
                if (index == 1) {
                    position = "1st";
                }
                else if (index == 2) {
                    position = "2nd";
                }
                else if (index == 3) {
                    position = "3rd"
                }
                else {
                    position = index + "th"
                }

                update(ref(db), {["/players/" + childSnapshot.key + "/leaderboardPosition"]: position});

                leaderboardData.username = childSnapshot.child("username").val();
                leaderboardData.highestScore = childSnapshot.child("highestScore").val();

                set(ref(db, "leaderboard/" + index), leaderboardData); // Pushing new data into Database
                index--;
            });
        }
    });
}

function updateLeaderboard(){
    retrieveLeaderboardData();
    
    setTimeout(() => {
        // Clear leaderboard content first
        $(".leaderboard__list").empty();

        // Appending header
        $(".leaderboard__list").append(`
            <li>
                <div class="leaderboard__list--content leaderboard__title--ranking">Ranking</div>
                <div class="leaderboard__list--content leaderboard__title--score">Score</div>
                <div class="leaderboard__list--content leaderboard__title--username">Username</div>
            </li>
        `);

        // Appending leaderboard data
        get(leaderboardRef).then((snapshot) => {
            if (snapshot.exists()) {
                snapshot.forEach((childSnapshot) => {
                    console.log(childSnapshot.val());
                    $(".leaderboard__list").append(`<li>
                        <div class="leaderboard__list--content leaderboard--ranking">${childSnapshot.key}</div>
                        <div class="leaderboard__list--content leaderboard--score">${childSnapshot.child("highestScore").val()}</div>
                        <div class="leaderboard__list--content leaderboard--username">${childSnapshot.child("username").val()}</div>
                    </li>`)
                })
            }
            else {

            }
        });
    }, 100);
    
}