  // Import the functions you need from the SDKs you need
  import { initializeApp } from "https://www.gstatic.com/firebasejs/9.5.0/firebase-app.js";
  import { getAnalytics } from "https://www.gstatic.com/firebasejs/9.5.0/firebase-analytics.js";
  // TODO: Add SDKs for Firebase products that you want to use
  // https://firebase.google.com/docs/web/setup#available-libraries

  // Your web app's Firebase configuration
  // For Firebase JS SDK v7.20.0 and later, measurementId is optional
  const firebaseConfig = {
    apiKey: "AIzaSyAYBK2gGs-bpK0Grm9MMgGZFyHukxwDU14",
    authDomain: "dda-db.firebaseapp.com",
    databaseURL: "https://dda-db-default-rtdb.asia-southeast1.firebasedatabase.app",
    projectId: "dda-db",
    storageBucket: "dda-db.appspot.com",
    messagingSenderId: "458168307324",
    appId: "1:458168307324:web:c9a67890797e11a08c43f9",
    measurementId: "G-0T5F4J3W71"
  };

  // Initialize Firebase
  const app = initializeApp(firebaseConfig);
  const analytics = getAnalytics(app);