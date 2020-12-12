import { ResourceLoader } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { defaultIfEmpty } from 'rxjs/operators';
import { FilterService } from 'src/app/services/filter.service';
import { LocalStorageService } from 'src/app/services/localStorage.service';

@Component({
    selector:'app-filters',
    templateUrl: './filters.component.html',
    styleUrls: ['./filters.component.css']
})
export class FiltersComponent implements OnInit{
    filterForm: FormGroup;    
    
    constructor(private builder: FormBuilder, private filterService: FilterService, private localStorageService: LocalStorageService) { }

    ngOnInit(){                
        this.buildForm(); 
        this.filter();
    }

    buildForm() {
      this.filterForm = this.builder.group({
        from: [this.localStorageService.get('fromFilter')],
        to: [this.localStorageService.get('toFilter')]
      });
    }

    filter(){
        this.localStorageService.set('fromFilter', this.filterForm.controls.from.value)
        this.localStorageService.set('toFilter', this.filterForm.controls.to.value);
        
        this.filterService.set(this.filterForm.controls.from.value, this.filterForm.controls.to.value)
        
    }
}
