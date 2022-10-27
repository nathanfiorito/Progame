import { AbstractControl, FormGroup } from "@angular/forms";

export function passwordMatch(password: string, passwordCofirm: string ){
    return (formGroup: FormGroup) => {
        const passwordControl = formGroup.controls[password];
        const confirmPasswordControl = formGroup.controls[passwordCofirm];
  
        if (!passwordControl || !confirmPasswordControl) {
          return null;
        }
  
        if (
          confirmPasswordControl.errors &&
          !confirmPasswordControl.errors.passwordMismatch
        ) {
          return null;
        }
  
        if (passwordControl.value !== confirmPasswordControl.value) {
          confirmPasswordControl.setErrors({ passwordMismatch: true });
            return true;
        } else {
          confirmPasswordControl.setErrors(null);
            return null;
        }
      };
}