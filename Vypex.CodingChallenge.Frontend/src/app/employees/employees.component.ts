import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NzButtonComponent } from 'ng-zorro-antd/button';
import { NzTableModule } from 'ng-zorro-antd/table';
import { EditEmployeeModal } from './edit-employee/edit-employee.modal';
import { Employee } from './models';
import { EmployeeApiService } from './services/employee-api.service';

@Component({
  selector: 'app-employees',
  imports: [NzTableModule, NzButtonComponent, AsyncPipe, FormsModule],
  providers: [EditEmployeeModal],
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.scss',
})
export class EmployeesComponent {
  private readonly employeeApiService = inject(EmployeeApiService);
  private readonly editEmployeeModal = inject(EditEmployeeModal);

  protected searchFilter = '';

  public employees$ = this.employeeApiService.getEmployees();

  public edit(employee: Employee) {
    this.editEmployeeModal
      .open({
        id: employee.id,
        name: employee.name,
        leaveDays: employee.leaveDays,
      })
      .afterClose.subscribe((result) => {
        if (result === undefined) return; // Modal cancelled.

        // 'edit-employee' form needs to stay open to show the results, so the results will be handled there.
      });
  }

  protected refresh(): void {
    this.employees$ = this.employeeApiService.getEmployees();
    this.searchFilter = '';
  }

  protected search(): void {
    this.employees$ = this.employeeApiService.getEmployees(this.searchFilter);
  }
}
