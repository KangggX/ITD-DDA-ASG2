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

onValue(playerRef, (snapshot) => {
    updateLeaderboard();
});

function retrieveLeaderboardData() {
    const que = query(playerRef, orderByChild("highestScore"));

    get(que).then((snapshot) => {
        if (snapshot.exists()) {
            console.log(snapshot.size)
            remove(leaderboardRef); // Delete current leaderboard data in Database

            let index = snapshot.size;

            snapshot.forEach((childSnapshot) => {
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