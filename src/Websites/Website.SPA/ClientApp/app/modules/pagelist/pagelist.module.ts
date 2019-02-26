import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { PagelistComponent } from "./pagelist.component";
import { SharedModule } from "../shared/shared.module";
import { RouterModule } from "@angular/router";

@NgModule({
    imports: [
        CommonModule,
        SharedModule,
        RouterModule
    ],
    declarations: [
        PagelistComponent
    ],
    exports: [
        PagelistComponent
    ]
})
export class PagelistModule { }