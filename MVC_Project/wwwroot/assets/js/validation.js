document.addEventListener("DOMContentLoaded", () => {
    // Handle signup form
    const signupForm = document.querySelector(".signup form");
    if (signupForm) {
        signupForm.addEventListener("submit", function (e) {
            const fullName = this.querySelector('input[placeholder="Full name"]').value.trim();
            const email = this.querySelector('input[placeholder="Email address"]').value.trim();
            const password = this.querySelector('input[placeholder="Password"]').value;
            const termsAccepted = this.querySelector("#signupCheck").checked;

            if (fullName === "") {
                alert("Please enter your full name.");
                e.preventDefault();
                return;
            }

            if (!validateEmail(email)) {
                alert("Please enter a valid email address.");
                e.preventDefault();
                return;
            }

            if (password.length < 6) {
                alert("Password must be at least 6 characters long.");
                e.preventDefault();
                return;
            }

            if (!termsAccepted) {
                alert("You must accept the terms and conditions.");
                e.preventDefault();
                return;
            }
        });
    }

    // Handle login form
    const loginForm = document.querySelector(".login form");
    if (loginForm) {
        loginForm.addEventListener("submit", function (e) {
            const email = this.querySelector('input[placeholder="Email address"]').value.trim();
            const password = this.querySelector('input[placeholder="Password"]').value;

            if (!validateEmail(email)) {
                alert("Please enter a valid email address.");
                e.preventDefault();
                return;
            }

            if (password.length < 6) {
                alert("Password must be at least 6 characters long.");
                e.preventDefault();
                return;
            }
        });
    }

    // Email format validator
    function validateEmail(email) {
        const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return re.test(email);
    }
});
