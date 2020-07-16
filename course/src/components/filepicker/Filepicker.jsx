import React from 'react';
import '../filepicker/Filepicker.css';
import axios from 'axios';
import Coursetable from '../table/Coursetable';
import Persontable from '../table/Persontable';
import Dropdown from '../filepicker/Dropdown';


export default class Filepicker extends React.Component {

    constructor(props) {
        super(props);
        this.getPerson()
        this.getCourse()
        this.state = {
            selectedFile: null,
            isVisible: true,
            persons: [],
            courses: [],
            name: null
        }
    }

    persons = [];
    getPerson() { 

        axios.get("http://192.168.0.94:8017/application/properties/person").then(res => {
            this.person = res.data
            this.person.forEach(option => {
            })
            this.setState({
                persons: this.person
            })

        }).catch(err => console.log(err))
    }

    courses = [];
    getCourse() {

        axios.get("http://192.168.0.94:8017/application/properties/course").then(res => {
            this.course = res.data
            this.course.forEach(option => {
            })

            this.setState({
                courses: this.course
            })

        }).catch(err => console.log(err))
    }


    onChangeHandler = event => {
        this.setState({
            selectedFile: event.target.files[0],
            loaded: 0,
        })
    }

    onClickHandler = (properties) => {
        const data = new FormData()
        data.append('file', this.state.selectedFile)
        data.append('properties', JSON.stringify(properties))

        axios.post("http://192.168.0.94:8017/application/" + this.state.name, data)
            .then(res => {   // then print response status
                console.log(res.statusText)
            })

        if (!this.state.selectedFile) {
            alert("Bitte Datei auswählen!")
            return;
        }
    }

    switchSite() {
        if (!this.state.isVisible) {
            if (this.state.persons.length > 0) {
                if (this.state.name !== "person")
                this.setState({name: "person"})
                return <Persontable personFields={this.state.persons} upload={this.onClickHandler} />
            }
        } else {
            if (this.state.courses.length > 0) {
                if (this.state.name !== "course")
                this.setState({name: "course"})
                return <Coursetable courseFields={this.state.courses} upload={this.onClickHandler} />
            } else {
                return null;
            }
        }
    }

    toggleClass = (selection) => {
        this.setState({
            isVisible: selection
        })
    }

    render() {
        return (
            <div>
                <div className="container">
                    <Dropdown toggleClass={this.toggleClass} />

                    <div className="body-filepicker">
                        <input type="file" name="file" onChange={this.onChangeHandler} />
                    </div>
                </div>
                <div className="switch">
                    {this.switchSite()}
                </div>
                {/* <Coursetable upload={this.onClickHandler} />
                <Persontable upload={this.onClickHandler} /> */}
            </div>
        )
    }
}