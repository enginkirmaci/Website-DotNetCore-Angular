import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DateTimeFormatPipe } from './pipes/datetimeformat.pipe';
import { ScriptComponent } from './components/script/script.component';

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [
        DateTimeFormatPipe,
        ScriptComponent
    ],
    exports: [
        DateTimeFormatPipe,
        ScriptComponent
    ]
})
export class SharedModule { }