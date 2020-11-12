export function passwordsMatchValidator(form) {       
    const password = form.get('password');
    const confirmPassword = form.get('confirmPassword');

    if(password.value !== confirmPassword.value){
        confirmPassword.setErrors({ passwordsMatch: true})
    }
    else{
        confirmPassword.setErrors(null)
    }
    return null
}