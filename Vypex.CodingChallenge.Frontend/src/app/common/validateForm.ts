import { FormGroup } from '@angular/forms';

export function validateForm(form: FormGroup): boolean {
  for (const control of Object.values(form.controls)) {
    if (control.invalid) {
      control.markAsDirty();
      control.updateValueAndValidity({ onlySelf: true });
    }
  }

  return form.valid;
}
