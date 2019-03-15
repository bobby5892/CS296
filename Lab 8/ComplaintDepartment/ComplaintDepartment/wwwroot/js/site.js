class ComplaintDepartment {
    constructor() {
        console.log("Loaded JS Complaint Department");
        this.bindEventsToButtons();

        this.is_edditing_complaint = false;
        this.complaintID = null;
        
        
        $('.openComplaints').each((i, obj) => {
            // This only occurs if its on the page and we pre-determined their is only 1 so it doesn't get called more than once.
            let url = window.location.protocol + "//" + window.location.host + "/Complaint/GetComplaints";
            console.log(url);
            fetch(url, {
                method: "GET"
            }).then(function (response) {
                    return response.json();
                })
                .then(function (myJSON) {
                    // Clear the boxes
                    $('.openComplaints')[0].innerHTML = "";
                    $('.closedComplaints')[0].innerHTML = "";
                    for (let i = 0; i < myJSON.length; i++) {
                        console.log("adding element");
                        let entry = `
                             <div class="complaint">
                                  <div class="complaint-date">${myJSON[i]['create']}</div>
                                  <div class="complaint-contents">${myJSON[i]['contents']}</div>
                                  <div class="complaint-details"><button class="complaint-details-button btn btn-primary" data-id="${myJSON[i]['id']}">Details</button></div>
                              </div>`;
                        if (!myJSON[i]['completed']) {
                            $('.openComplaints')[0].innerHTML += entry;
                        }
                        else {
                            $('.closedComplaints')[0].innerHTML += entry;
                            console.log("closed");
                        }
                        
                    }

                }).then(() =>{
                    console.log("finally");
                    this.bindEventsToButtons();
                });            
        });
        
    }
    showComplaint(id) {
        let url = window.location.protocol + "//" + window.location.host + "/Complaint/Get/" + id;
        console.log(url);
        fetch(url, {
            method: "GET"
        })
            .then(function (response) {
                return response.json();
            })
            .then(function (myJson) {
                console.log(JSON.stringify(myJson));
                $("#modal").html(`<div class='closeModal'>X</div><div class="complaint">
                <div class="complaint-date">${myJson['create']}</div>
                <div class="complaint-contents">${myJson['contents']}</div>
                <div class="complaint-markcomplete">
                    <button class="complaint-mark-icon btn btn-primary" data-id="${myJson['id']}"></button>
                </div>
                <div class="complaint-addcomment"><button class="complaint-edit-button btn btn-primary" data-id="${myJson['id']}">Edit</button></div>
                <div class="complaint-addcomment"><button class="complaint-mark-comment btn btn-primary" data-id="${myJson['id']}">Comment</button></div>
                <div class="complaint-addcomment"><button class="complaint-delete-button btn btn-danger" data-id="${myJson['id']}">Delete</button></div>

                <div class="comments"></div>
            </div>
            `);
                if (myJson['completed']) {
                    $('button.complaint-mark-icon').html('Mark Incomplete');
                }
                else {
                    $('button.complaint-mark-icon').html('Mark Complete');
                }
            /*Lets Grab Comments*/
               
                let url = window.location.protocol + "//" + window.location.host + "/Complaint/GetCommentsByComplaint?id=" + myJson['id'];
                console.log(url);

                fetch(url, {
                    method: "POST",
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({id:myJson['id']})
                })
                    .then(function (response) {
                        return response.json();
                    })
                    .then( (myInnerJson) => {
                        for (let j = 0; j < myInnerJson.length; j++) {
                            $(".comments").append(
                                `<div class="comment">
                                    <span>Comment</span><p> ${ myInnerJson[j]['contents']}</p><button class="delete-comment-button btn btn-danger" data-id="${myInnerJson[j]['id']}">Delete</button>
                                </div>`
                           );
                        }
                        // Bind the Comment Delete Buttons
                        this.bindEventsToButtons();
                    })
            }.bind(this)).then(() => {
                /// Bind Comment Button
                this.bindEventsToButtons();
            });     
        this.showModal();
    }
    showModal() {
        if ($('#modal').length == 0) {
            // Add to top
            $("body").prepend("<div class='mask'><div id='modal' class='modaler'></div></div>");
            this.bindEventsToButtons();
        }
    }
    hideModal() {
        if ($('#modal').length != 0) {
            /* Clear all Masks - Sometimes there are more than 1*/
            for (let i = 0; i <= document.getElementsByClassName("mask").length; i++) {
                console.log("clearing a mask");
                document.getElementsByTagName("body")[0].removeChild(document.getElementsByClassName("mask")[0]);
            }
        }
    }

    bindEventsToButtons() {
        /* find Comment buttons */
        $('.complaint-mark-comment').each((i, obj) => {
            /* check if bound already */
            //$(obj).unbind('click.namespace').bind('click.namespace', function () { });
            $(obj).unbind('click.namespace').bind("click", () => {
                // Show Add Comment Form
                let id = obj.dataset["id"];
                complaint.showCommentForm(id);
                this.bindEventsToButtons();
            });
           
        });
        /* find Details buttons - Redirect Version */
        /*$('.complaint-details-button').each((i, obj) => {
            obj.addEventListener("click", () => {
                let id = obj.dataset["id"];
                let url = window.location.protocol + "//" + window.location.host + "/Complaint/Get/" + id;
                console.log("Redirecting to url");
                location.replace(url);
            });
        });
        */
        $('.complaint-details-button').each((i, obj) => {
             /* check if bound already */
            
            $(obj).unbind('click.namespace').bind("click", () => {
                    console.log("I was clicked");
                    let id = obj.dataset["id"];
                    this.showComplaint(id);
                });
            
        });
        /* find Mark buttons - using jquery*/
        $('.complaint-mark-icon').each((i, obj) => {
            $(obj).unbind('click.namespace').bind("click", () => {
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
            $(obj).unbind('click.namespace').bind("click", () => {
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
            $(obj).unbind('click.namespace').bind("click", () => {
                    let id = obj.dataset["id"];
                    if (id.length > 0) {
                        complaint.deleteComplaint(id);
                    }
                    else {
                        console.log("Invalid ID");
                    }
                });
        });
        /* Find close modal buttons */
        $('.closeModal').each((i, obj) => {
            $(obj).unbind('click.namespace').bind("click", () => {
                    this.hideModal();
                });
        });        
        /* Find edit modal buttons */
        $('.complaint-edit-button').each((i, obj) => {
            $(obj).unbind('click.namespace').bind("click", () => {
                    let id = obj.dataset["id"];
                    console.log("clicking to show edit form" + id);
                    this.complaintID = id;
                    this.showEditForm();
                });
        });

        /* Setup for Focus out on edit complaint */
        $('.editing_a_complaint').each((i, obj) => {
            $(obj).unbind('click.namespace').bind("click", () => {
                /* obj.addEventListener("onfocusout", (() => {
                     console.log("trying to hide");
                     this.hideEditForm();
                 }).bind(this));
                 */
                $(obj).blur(() => {
                    this.hideEditForm();
                });
            });
        });
        // Bind the cancel button
        $('.cancel-comment').each((i, obj) => {
            $(obj).unbind('click.namespace').bind("click", () => {
                console.log("canceling");
                let url = window.location.protocol + "//" + window.location.host + "/Complaint/Get/" + obj.dataset["id"];
                location.replace(url);
            });
        });
        // Handle the add button
        $('.add-comment').each((i, obj) => {
            
            $(obj).unbind('click.namespace').bind("click", () => {
                    let idComment = obj.dataset["id"];
                    let contents = document.getElementsByClassName("text-comment")[0].value;
                    // Don't do anything if its blank
                    if (contents.length == 0) { console.log('skipped no contents'); return false; }
                    let url = window.location.protocol + "//" + window.location.host + "/Complaint/AddComment?id=" + idComment + "&content=" + contents;
                    console.log("CONTENTS - THAT SHOULD BE SENT" + contents);
                    fetch(url, {
                        method: "POST",
                        body: JSON.stringify({
                            id: idComment,
                            content: contents
                        })
                    })
                        .then(function (response) {
                            return response.json();
                        })
                        .then(((myJson) => {
                            console.log(JSON.stringify(myJson));
                            //location.reload();
                            this.hideModal();
                            this.showComplaint(idComment);
                        }));
                });
        });
               
    }
    showEditForm() {
        
        this.is_edditing_complaint = true;
        let contents = $(".complaint-contents")[0].textContent;
        $(".complaint-contents")[0].innerHTML = "<textarea class='editing_a_complaint'>" + contents + "</textarea>";
        this.bindEventsToButtons();
    }
    hideEditForm() {
        console.log("hide edit form" + this.complaintID);
        let contents = $(".editing_a_complaint")[0].value;
        
        $(".complaint-contents")[0].innerHTML = contents;
        let url = window.location.protocol + "//" + window.location.host + "/Complaint/EditComplaint?id=" + this.complaintID+ "&contents=" + contents + "&completed=false";
        console.log(url);
        fetch(url, {
            method: "PUT"
        })
            .then(function (response) {
                return response.json();
            })
            .then(function (myJson) {
                console.log(JSON.stringify(myJson));
                console.log("--SAVED complaint");
            });


        this.is_edditing_complaint = false;
    }
    deleteComplaint(id) {
        let url = window.location.protocol + "//" + window.location.host + "/Complaint/DeleteComplaintByID?id=" + id;
        console.log(url);
        fetch(url, {
            method: "DELETE"
        })
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
        fetch(url, {
            method: "DELETE"
        })
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
        fetch(url, {
            method: "PATCH"
        })
        .then(function (response) {
            return response.json();
        })
        .then(function (myJson) {
            console.log(JSON.stringify(myJson));
            location.reload();
        });
    }
    replaceComplaint(id,time,content,completed) {
        let url = window.location.protocol + "//" + window.location.host + "/Complaint/EditComplaint?id=" + id + "&create=" + time + "&contents="
            + content + "&completed=" + completed;
        console.log(url);
        fetch(url, {
            method: "PUT"
        })
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
        if (document.getElementsByClassName("text-comment").length == 0) {
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
        }
        
    }
}

let complaint;

window.addEventListener("load", () => {
    complaint = new ComplaintDepartment();
})