$(document).ready(() => {

    $(document).ajaxError((doc, xhr) => {
        console.log(xhr.status);
        if (xhr.status == 401) {

            window.location.href = "/Authorization/SignIn"
        }
    })
})

function checkLogin() {
    var username = document.getElementsByName('username');
    var password = document.getElementsByName('password');

    var error = null;

    if (username == '')
        error = 'Username cannot be empty!';

    if (error) {
        alert(error);
        return false;
    }

    if (password = '')
        error = 'password cannot be empty';

    if (error) {
        alert(error);
        return false;
    }

    return true;
}

function checkSignUp() {
    var inputs = {
        fname: document.getElementsByName('Fname')[0].value,
        lname: document.getElementsByName('Lname')[0].value,
        email: document.getElementsByName('email')[0].value,
        password: document.getElementsByName('password')[0].value,
        passwordCheck: document.getElementsByName('cpassword')[0].value
    }

    //console.log(inputs);

    var error = null;

    if (inputs.password != inputs.passwordCheck)
        error = 'Passords dont match';

    if (error) {
        alert(error);
        return false;
    }

    if (!(/^(\w|\.)*@\w*\.\w*$/).test(inputs.email))
        error = 'Email format incorrect!';

    if (error) {
        alert(error);
        return false;
    }

    return true;
}

function checkUserDetails(e) {
    if ($('[name="name"]').val() == '') {
        alert('Name cannot be empty');
        e.preventDefault();
        return false;
    }

    if ($('[name="newPassword"]').val() != '' || $('[name="confirmPassword"]').val() != '') {
        if ($('[name="newPassword"]').val() != $('[name="confirmPassword"]').val()) {
            alert("Password and confirm password must match");
            e.preventDefault()
            return false;
        }

        if ($('[name="oldPassword"]').val() == '') {
            alert("Old password cannot be empty");
            e.preventDefault();
            return false;
        }
    }

    return true;
}

function likeTweet(event) {
    var parent = $(event.target).parents('.tweet');
    var tweetId = parent.data('tweetId');

    $.post(
        '/Tweet/LikeTweet',
        { tweetId: tweetId },
        (res) => { parent.replaceWith(res) }
    )
}

function loadComments(event) {
    event.preventDefault();
    var parent = $(event.target).parents('.tweet');
    var commentsContainer = parent.find('.comments');
    var tweetId = parent.data('tweetId');

    $.get('/Tweet/TweetComments?tweetId=' + tweetId, (data) => commentsContainer.html(data));
}

function addComment(event) {
    event.preventDefault();
    var parent = $(event.target).parents('.tweet');
    var tweetId = parent.data('tweetId');
    var content = parent.find('.comment-input').val();
    var commentsContainer = parent.find('.comments');

    if (content.trim().length > 0) {
        $.post(
            '/Tweet/AddComment',
            { tweetId: tweetId, content: content },
            (data) => {
                commentsContainer.html(data);
                var nComments = parent.find('.nComments')
                nComments.text(Number.parseInt(nComments.text()) + 1);
            }
        )
    }
}

function likeComment(event) {
    var parent = $(event.target).parents('.tweet');
    var tweetId = parent.data('tweetId');
    var commentId = $(event.target).parents('.tweet-comment').data('commentId');
    var commentContainer = $(event.target).parents('.comments')

    $.post(
        '/Tweet/LikeComment',
        { tweetId: tweetId, commentId: commentId },
        (res) => { commentContainer.html(res) }
    )
}