// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function PreviewImage(source) {
  //  window.alert(source.id);
    var file = source.files[0];
    if (window.FileReader) {
        var fr = new FileReader();
        fr.onloadend = function (e) {
            document.getElementById("preview").src = e.target.result;
        };
        fr.readAsDataURL(file);
    }
}

// 載入圖片失敗時, 使用預設圖片
function imgUserAvatarError(image) {
    image.src = '@Url.Content("~/images/a1.png")';
    return true;
}