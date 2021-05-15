async function viewComments(photoId, selector) {
    const htmlElement = $(`#commentsPhoto${photoId}`);
    const htmlElementRow = $(`#rowComments${photoId}`);
    htmlElement.html("");
    let response = await fetch(`comments/${photoId}`)
        .then((response) => response.text())
        .then((result) => {
            htmlElement.html(result);
            htmlElementRow.show("slow");
        });
}

$(document).ready(() => {
   $("#btnVerAlbum").on("click", async (evArgs) => {
       const albumId = $("#AlbumId").val();
       $("#photosTable").html("");
       let response = await fetch(`albums/${albumId}`)
           .then((response) => response.text())
           .then((result) => {
               $("#photosTable").html(result);
           });
   });
});