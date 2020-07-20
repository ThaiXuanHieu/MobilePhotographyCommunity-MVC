function addImage(input) {
    if (input.files && input.files[0]) {
        var filerdr = new FileReader();
        filerdr.onload = function (e) {
            document.getElementById("img-preview").src = e.target.result;
            document.getElementsByClassName("region-img-preview")[0].style.display = "block";
        }
        filerdr.readAsDataURL(input.files[0]);
    }
}

function uploadAvatar(input) {
    if (input.files && input.files[0]) {
        var filerdr = new FileReader();
        filerdr.onload = function (e) {
            document.getElementById("avatar").src = e.target.result;
        }
        filerdr.readAsDataURL(input.files[0]);
    }
}

// Get the modal
var modal = document.getElementById("modal-img");

// Get the image and insert it inside the modal - use its "alt" text as a caption
var img = document.getElementsByClassName("photo");
var modalImg = document.getElementById("img");
for (var i = 0; i < img.length; ++i) {
    img[i].onclick = function () {
        modal.style.display = "block";
        modalImg.src = this.src;
    }
}

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

var descriptionChallenge = document.getElementsByClassName("description-challenge")[0];
var colLeft = document.getElementsByClassName("col-left")[0];
var colRight = document.getElementsByClassName("col-right")[0];
var colCenter = document.getElementsByClassName("col-center")[0];
var closeDescription = document.getElementsByClassName("close-description")[0];
closeDescription.onclick = function () {
    descriptionChallenge.style.display = 'none';
    colLeft.style.marginTop = '70px';
    colRight.style.marginTop = '70px';
    colCenter.style.marginTop = '70px';
}