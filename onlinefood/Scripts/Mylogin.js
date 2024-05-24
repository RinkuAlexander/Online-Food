function checkfname() {
    var isName = /^[a-zA-Z]+$/;
    let fnameValue = document.getElementById("fname")
    if (fnameValue.value.trim() === "") {
        setErrorFor(fnameValue, "FirstName required");
    }
    else if (!isName.test(fnameValue.value.trim())) {
        setErrorFor(fnameValue, 'Name cannot be a numbers or special characters');
    }
    else {
        setSuccessFor(fnameValue);
    }
}

function checkpassword() {
    var isPassword = /^(?=.\d)(?=.[a-z])(?=.*[A-Z]).{8,20}$/;
    let passwordValue = document.getElementById("password")
    let cpasswordValue = document.getElementById("cpassword")
    if (passwordValue.value.trim() === "") {
        setErrorFor(passwordValue, " password Required");
    }
    else if (passwordValue.value.trim() !== cpasswordValue.value.trim()) {
        setErrorFor(passwordValue, "The password does not match");
    }
    else if (!isPassword.test(passwordValue.value.trim())) {
        setErrorFor(password, 'Password should only contain 8-20 characters and contains combination of uppercase and lowercase');

    }
    else {
        setSuccessFor(passwordValue);
    }
}

function checkvalidation() {
    checkfname();
    checkpassword();
}

let popup = document.getElementById("popup");
function openpopup() {
    popup.classList.add("open-popup");
}
function closepopup() {
    popup.classList.remove("open-popup");
}