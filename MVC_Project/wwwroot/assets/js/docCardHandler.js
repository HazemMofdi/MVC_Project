
window.addEventListener("DOMContentLoaded", function () {
    let docCards = document.querySelectorAll(".doctor-card");
    let docBtns = document.querySelectorAll(".doc-btn");
    let dbDoctorNames = document.querySelectorAll(".DB-doctor-name");

    docBtns.forEach((btn, index) => {
        // Hide all doctor cards initially 
        btn.addEventListener("click", function () {
            docCards.forEach(card => {
                card.style.display = "none";
                document.body.style.setProperty('--before-width', '100%');
            });
            
          
            //
            let docCard = docCards[index];
            let docName = docCard.querySelector(".doctor-name");
            let doctorSpecialty = docCard.querySelector(".doctor-specialty");
            let doctorExp = docCard.querySelector(".doctor-experience");
            //let doctorRating = docCard.querySelector(".doctor-rating");
            //let doctorBio = docCard.querySelector(".doctor-bio");
            let doctorPrice = docCard.querySelector(".doctor-price");
            let docImg = docCard.querySelector(".doctor-image");

            let clickedDoctorName = dbDoctorNames[index].textContent.trim().toLowerCase();

            docCard.style.display = "block";

            switch (clickedDoctorName) {
                case "hazem mofdi":
                    docName.textContent = "Hazem Mofdi";
                    doctorSpecialty.textContent = "Psychiatrist";
                    doctorExp.textContent = "10 years of experience";
                    doctorPrice.textContent = "Session Price: 200 $";
                    docImg.src = "/assets/img/doctors/doctors-1.jpg";
                    break;

                case "hassan atef":
                    docName.textContent = "Hassan Atef";
                    doctorSpecialty.textContent = "Cardiologist";
                    doctorExp.textContent = "15 years of experience";
                    doctorPrice.textContent = "Session Price: 300 $";
                    docImg.src = "/assets/img/doctors/doctors-1.jpg";
                    break;

                case "hamss mohammed":
                    docName.textContent = "Hams Mohammed";
                    doctorSpecialty.textContent = "Dermatologist";
                    doctorExp.textContent = "8 years of experience";
                    doctorPrice.textContent = "Session Price: 250 $";
                    docImg.src = "/assets/img/doctors/doctors-2.jpg";
                    break;

                case "rahma tarek":
                    docName.textContent = "Rahma Tarek";
                    doctorSpecialty.textContent = "Dentist";
                    doctorExp.textContent = "12 years of experience";
                    doctorPrice.textContent = "Session Price: 220 $";
                    docImg.src = "/assets/img/doctors/doctors-2.jpg";
                    break;

                case "nancy saad":
                    docName.textContent = "Nancy Saad";
                    doctorSpecialty.textContent = "Pediatrician";
                    doctorExp.textContent = "9 years of experience";
                    doctorPrice.textContent = "Session Price: 280 $";
                    docImg.src = "/assets/img/doctors/doctors-2.jpg";
                    break;

                default:
                    console.log("Doctor not found.");
                    break;
            }
        });
    });
   
    // exit opend card
    document.querySelectorAll(".exit").forEach(exitBtn => {
        exitBtn.addEventListener("click", function () {
            this.parentElement.style.display = "none";
            document.body.style.setProperty('--before-width', '0');
        });
    });
});
