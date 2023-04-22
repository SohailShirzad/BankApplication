const prevBtns = document.querySelectorAll(".btn-prev");
const nextBtns = document.querySelectorAll(".btn-next");
const progress = document.getElementById("progress");
const formSteps = document.querySelectorAll(".form-step");
const progressSteps = document.querySelectorAll(".progress-step");
const addExperienceBtn = document.querySelector(".add-exp-btn");
const experiencesGroup = document.querySelector(".experiences-group");
const btnComplete = document.querySelector(".btn-complete");
btnComplete.addEventListener("click", () => {
    document.getElementsByTagName('form').submit
})
let formStepsNum = 0;
let experienceNum = 1;

addExperienceBtn.addEventListener("click", () => {
    experienceNum++;
    let text = `
        <hr>
    <div class='experience-item'>
        <div class='input-group' >
        <label for='title'>Company name</label>
        <input type='text' name='title[]' id='title'>
    </div>
    <div class='input-group'>
        <label for='start-date'>Start date</label>
        <input type='date' name='start-date[]' id='start-date'>
    </div>
    <div class='input-group'>
        <label for='end-date'>End date</label>
        <input type='date' name='nd-date[]' id='end-date'>
    </div>
    <div class='input-group'>
        <label for='job-description'>Description</label>
        <textarea name='job-description[]' id='job-description' cols='42' rows='6'></textarea>
    </div>
</div > `
    experiencesGroup.insertAdjacentHTML('beforeend', text);
})

function updateFormSteps() {

    formSteps.forEach(formStep => {
        formStep.classList.contains("active") &&
            formStep.classList.remove("active");
    })
    formSteps[formStepsNum].classList.add("active");
}

function updateProgressBar() {
    progressSteps.forEach((progressStep, idx) => {
        if (idx < formStepsNum + 1) {
            progressStep.classList.add("active");
        } else {
            progressStep.classList.remove("active");
        }
    })

    const progressActive = document.querySelectorAll(".progress-step.active");
    progress.style.width = ((progressActive.length - 1) / (progressSteps.length - 1)) * 100 + '%';
}


nextBtns.forEach(btn => {
    btn.addEventListener("click", function () {
        formStepsNum++;
        updateFormSteps();
        updateProgressBar();
        console.log("kk")
    })
})


prevBtns.forEach(btn => {
    btn.addEventListener("click", function () {
        formStepsNum--;
        updateFormSteps();
        updateProgressBar();
        console.log("kk")
    })
})
