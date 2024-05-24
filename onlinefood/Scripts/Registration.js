function checkfname() {
    var isName = /^[a-zA-Z]+$/;
    let fnameValue = document.getElementById("fname")
    if (fnameValue.value.trim() === "") {
        setErrorFor(fnameValue, "FirstName required");
        fname.style.border = "1px solid red";
    }
    else if (!isName.test(fnameValue.value.trim())) {
        setErrorFor(fnameValue, 'Name cannot be a numbers or special characters');
        fname.style.border = "1px solid silver";
    }
    else {
        setSuccessFor(fnameValue);
    }
}

//Last Name validation
function checkLname() {
    var isName = /^[a-zA-Z]+$/;
    let LnameValue = document.getElementById("Lname")
    if (LnameValue.value.trim() === "") {
        setErrorFor(LnameValue, "Lastname Required");
    }
    else if (!isName.test(LnameValue.value.trim())) {
        setErrorFor(LnameValue, 'Name cannot contain numbers or special characters');
    }
    else {
        setSuccessFor(LnameValue);
    }
}

//DOB validation

function checkDob() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }

    today = yyyy + '-' + mm + '-' + dd;
    document.getElementById("DOB").setAttribute("max", today);
}

//Contact number validation
function checkcontact() {
    var isNumber = /^[0-9]+$/;
    let contactValue = document.getElementById("contact")
    if (contactValue.value.trim() === "") {
        setErrorFor(contactValue, 'Phonenumber Required');
    }
    else if (!isNumber.test(contactValue.value.trim())) {
        setErrorFor(contactValue, 'Check Phonenumber');

    }
    else {
        setSuccessFor(contactValue);
    }

}

//Email Validation
function checkemail() {
    var isMail = /^\w+([\.-]?\w+)@\w+([\.-]?\w+)(\.\w{2,3})+$/;
    let mailValue = document.getElementById("mail")
    if (mailValue.value.trim() === '') {
        setErrorFor(mailValue, 'Email Rquried');
    }
    else if (!isMail.test(mailValue.value.trim())) {
        setErrorFor(mailValue, 'Email ID is not valid');

    }
    else {
        setSuccessFor(mailValue);
    }
}

//Address validation
function checkadd() {
    let addValue = document.getElementById("add")
    if (addValue.value.trim() === "") {
        setErrorFor(addValue, "Please enter address");
    }
    else {
        setSuccessFor(addValue);
    }
}


//UserName

function checkUsername() {
    let usernamevalue = document.getElementById("username")
    var admin = "Admin";
    if (usernamevalue.value.trim() == "") {
        setErrorFor(usernamevalue, "Please enter UserName")
    }

    else {
        setSuccessFor(usernamevalue)
    }
}

//Password validation
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

//Shows your Error message

function setErrorFor(input, message) {
    var form = input.parentElement;
    var small = form.querySelector('small')
    small.innerText = message;
    form.className = 'form error'
}


function setSuccessFor(input) {
    var form = input.parentElement;
    form.className = 'form success';

}



function checkvalidation() {
    checkfname();
    checkemail();
    checkLname();
    checkUsername();
    checkpassword();
    checkemail();
    checkcontact();
    checkadd();
    checkDob();
}

let popup = document.getElementById("popup");
function openpopup() {
    popup.classList.add("open-popup");
}
function closepopup() {
    popup.classList.remove("open-popup");
}
