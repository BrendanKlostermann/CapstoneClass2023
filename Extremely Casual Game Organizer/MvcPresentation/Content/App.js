
var openMessage = getCookie("openMessage");
console.log("value = " + openMessage);

if (openMessage == "") {
    console.log("first time");
    document.getElementById("myForm").style.display = "none";
    document.getElementById("btnOpen").style.display = "block";
    document.getElementById("btnOpenMobile").style.display = "block";
} else {
    console.log("more times");
    document.getElementById("btnOpen").style.display = "none";
    document.getElementById("btnOpenMobile").style.display = "none";
    AOS.init();
}

setCookie("openMessage", "");


//alert(location.pathname);
if (location.pathname.includes("/Messages")) {
    //alert("yes");
    document.getElementById("btnOpen").style.display = "none";
    document.getElementById("btnOpenMobile").style.display = "none";
    document.getElementById("footer").style.display = "none";
    scrollBottom();
}

function openForm() {
    setCookie("openMessage", true);
    openMessage = getCookie("openMessage");
    console.log("Open = " + openMessage);
    location.reload();
}

function closeForm() {
    //alert("pp");
    setCookie("openMessage", "");
    document.getElementById("myForm").style.display = "none";
    document.getElementById("btnOpen").style.display = "block";
    document.getElementById("btnOpenMobile").style.display = "block";
    openMessage = getCookie("openMessage");
    console.log("Close = " + openMessage);
    location.reload();
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(";");
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == " ") {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function setCookie(name, value) {
    var d = new Date();
    d.setTime(d.getTime() + 5 * (365 * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = name + "=" + value + ";" + expires + ";path=/";
}

function scrollBottom() {
    var divMessage = document.getElementById("divMessage");
    divMessage.scroll({ top: divMessage.scrollHeight, behavior: 'smooth' });
}

function previewImage(event) {
    var selectedFile = event.target.files[0];
    var reader = new FileReader();

    var imgtag = document.getElementById("image-preview");
    imgtag.title = selectedFile.name;

    reader.onload = function (event) {
        imgtag.src = event.target.result;
    };

    reader.readAsDataURL(selectedFile);
}


function previewImagesss(e) {
    console.log(e);
    console.log("element");
    var element = e.target.files[0];

    var image = document.getElementById("image-preview");
    console.log("image");
    console.log(image);

    image.setAttribute("src", element)

    //setCookie("image", element);
    console.log(element);

}