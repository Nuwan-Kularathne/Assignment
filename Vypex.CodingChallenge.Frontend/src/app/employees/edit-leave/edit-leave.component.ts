import { CommonModule } from '@angular/common';
import {
  ChangeDetectorRef,
  Component,
  inject,
  Input,
  OnInit,
} from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { catchError, finalize, of, tap } from 'rxjs';
import { validateForm } from '../../common/validateForm';
import { EmployeeApiService } from '../services/employee-api.service';

@Component({
  selector: 'app-edit-leave',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NzFormModule,
    NzButtonModule,
    NzInputModule,
  ],
  templateUrl: './edit-leave.component.html',
  styleUrl: './edit-leave.component.scss',
  standalone: true,
})
export class EditLeaveComponent implements OnInit {
  @Input() leaveDay!: { id: string; startDate: string; endDate: string };

  protected inEditMode = false;
  protected deleted = false;
  protected errorText = '';

  private readonly fb = inject(FormBuilder);
  private readonly employeeApiService = inject(EmployeeApiService);
  private readonly cdr = inject(ChangeDetectorRef);

  protected leaveUpdateForm = this.fb.group({
    id: this.fb.nonNullable.control('', Validators.required),
    startDate: this.fb.nonNullable.control('', Validators.required),
    endDate: this.fb.nonNullable.control('', Validators.required),
  });

  ngOnInit(): void {
    this.leaveUpdateForm.setValue({
      id: this.leaveDay.id,
      startDate: this.leaveDay.startDate.split('T')[0],
      endDate: this.leaveDay.endDate.split('T')[0],
    });
  }

  protected edit() {
    this.inEditMode = true;
    this.errorText = '';
  }

  protected submit() {
    if (!validateForm(this.leaveUpdateForm)) {
      this.errorText = 'Start and end dates should be valid.';
      return;
    }

    const formValue = this.leaveUpdateForm.getRawValue();

    const date1 = new Date(formValue.startDate);
    const date2 = new Date(formValue.endDate);

    if (!date1.getTime() || !date2.getTime()) {
      return;
    }

    if (date1 >= date2) {
      this.errorText = 'Start date should be earlier than the end date.';
      return;
    }

    this.employeeApiService
      .updateLeave(formValue.id, formValue.startDate, formValue.endDate)
      .pipe(
        tap(() => {
          this.leaveDay.startDate = formValue.startDate;
          this.leaveDay.endDate = formValue.endDate;
          this.inEditMode = false;
          this.errorText = '';
        }),
        catchError((error) => {
          console.log(error);
          this.errorText = 'Network error';

          return of(null);
        }),
        finalize(() => {
          this.cdr.detectChanges();
        })
      )
      .subscribe();
  }

  protected clearErrors(): void {
    this.errorText = '';
  }

  protected cancel() {
    this.inEditMode = false;
    this.errorText = '';
  }

  protected delete() {
    this.employeeApiService
      .deleteLeave(this.leaveDay.id)
      .pipe(
        tap(() => {
          this.deleted = true;
        }),
        catchError((error) => {
          console.log(error);
          this.errorText = 'Network error';
          return of(null);
        }),
        finalize(() => {
          this.cdr.detectChanges();
        })
      )
      .subscribe();
  }
}
