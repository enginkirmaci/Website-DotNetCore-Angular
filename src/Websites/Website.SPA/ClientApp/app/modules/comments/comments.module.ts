import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { SharedModule } from "../shared/shared.module";
import { CommentsComponent } from "./comments.component";

@NgModule({
    imports: [
        CommonModule,
        SharedModule
    ],
    declarations: [
        CommentsComponent
    ],
    exports: [
        CommentsComponent
    ]
})
export class CommentsModule { }