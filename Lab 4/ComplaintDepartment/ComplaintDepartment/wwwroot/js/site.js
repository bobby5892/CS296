class ComplaintDepartment {
    constructor() {
        console.log("Loaded JS Complaint Department");
        /* find Comment buttons */
        $('.complaint-mark-comment').each((i, obj) => {
            obj.addEventListener("click", () => {
                // Show Add Comment Form
                let id = obj.dataset["id"];
                complaint.showCommentForm(id);
            });
        });
        /* find Details buttons */
        $('.complaint-details-button').each((i, obj) => {
            obj.addEventListener("click", () => {
                let id = obj.dataset["id"];
                let url = window.location.protocol + "//" + window.location.host + "/Complaint/Get/" + id;
                console.log("Redirecting to url");
                location.replace(url);
            });
        });
        /* find Mark buttons - using jquery*/
        $('.complaint-mark-icon').each((i, obj) => {
            console.log("Detected Mark Complete Button");
            obj.addEventListener("click", () => {
                let id = obj.dataset["id"];
                if (id.length > 0) {
                    complaint.markComplete(id);
                    console.log("Clicking Mark Complete" + id);
                }
                else {
                    console.log("Invalid ID");
                }

            });
        });
        /* find Delete comment buttons */
        $('.delete-comment-button').each((i, obj) => {
            console.log("Detected Delete Comment Button");
            obj.addEventListener("click", () => {
                let id = obj.dataset["id"];
                if (id.length > 0) {
                    complaint.deleteComment(id);
                }
                else {
                    console.log("Invalid ID");
                }

            });
        });
        /* Find delete complaint buttons */
       
        $('.complaint-delete-button').each((i, obj) => {
            console.log("Detected Delete Complaint Button");
            obj.addEventListener("click", () => {
                let id = obj.dataset["id"];
                if (id.length > 0) {
                    complaint.deleteComplaint(id);
                }
                else {
                    console.log("Invalid ID");
                }

            });
        });
        
    }
    deleteComplaint(id) {
        let url = window.location.protocol + "//" + window.location.host + "/Complaint/DeleteComplaintByID?id=" + id;
        console.log(url);
        fetch(url)
            .then(function (response) {
                return response.json();
            })
            .then(function (myJson) {
                console.log(JSON.stringify(myJson));
                location.replace(window.location.protocol + "//" + window.location.host + "/Complaint/List");
            });
    }
    deleteComment(id) {
        let url = window.location.protocol + "//" + window.location.host + "/Complaint/DeleteCommentById?id=" + id;
        console.log(url);
        fetch(url)
            .then(function (response) {
                return response.json();
            })
            .then(function (myJson) {
                console.log(JSON.stringify(myJson));
                location.reload();
            });
    }
    markComplete(id) {
        console.log("Trigger mark complete:" + id);
        let url = window.location.protocol + "//" + window.location.host + "/Complaint/ToggleComplete?id=" + id;
        console.log(url);
        fetch(url)
            .then(function (response) {
                return response.json();
            })
            .then(function (myJson) {
                console.log(JSON.stringify(myJson));
                location.reload();
            });
    }
    /* Show HTML Form for submitting a comment*/
    showCommentForm(id) {
        // would normall use a modal - but this is quick and dirty for an academic exercise
        $("body").append(
            `<div class='mask'>
                <div class='addCommentform'>
                        <span>Add Comment</span>
                        <br>
                        <textarea name="comment" class="text-comment"></textarea>
                        <br>
                        <button class="add-comment" data-id="${id}">add</button>
                        <button class="cancel-comment" data-id="${id}">Cancel</button>

                </div>
            </div>`
        );
        // Bind the cancel button
        $('.cancel-comment').each((i, obj) => {
            obj.addEventListener("click", () => {
                console.log("canceling");
                let url = window.location.protocol + "//" + window.location.host + "/Complaint/Get/" + obj.dataset["id"];
                location.replace(url);
            });
        });
         // Handle the add button
         $('.add-comment').each((i, obj) => {
                obj.addEventListener("click", () => {
                    let url = window.location.protocol + "//" + window.location.host + "/Complaint/AddComment?id=" + id + "&content=" + $('.text-comment').val();
                    console.log(url);
                    fetch(url)
                        .then(function (response) {
                            return response.json();
                        })
                        .then(function (myJson) {
                            console.log(JSON.stringify(myJson));
                            location.reload();
                        });
                });
         });
    }
}

let complaint;

window.addEventListener("load", () => {
    complaint = new ComplaintDepartment();
})