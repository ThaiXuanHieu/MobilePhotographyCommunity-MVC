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

function like(){
    document.querySelector('.btn-like, .btn-like i').style.color = 'blue';
}