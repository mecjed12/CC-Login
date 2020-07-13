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
            courses: []
        }
    }

    persons = [];
    getPerson() {

        var xhttp = new XMLHttpRequest();

        axios.get("http://192.168.0.94:8017/application/properties/person").then(res => {
            this.person = res.data
            this.person.forEach(option => {
            })

            this.setState({
                persons: this.person
            })
            console.log(this.person)
        }).catch(err => console.log(err))
    }

    courses = [];
    getCourse() {

        var xhttp = new XMLHttpRequest();

        axios.get("http://192.168.0.94:8017/application/properties/course").then(res => {
            this.course = res.data
            this.course.forEach(option => {
            })

            this.setState({
                courses: this.course
            })
            console.log(this.course)
        }).catch(err => console.log(err))
    }


    onChangeHandler = event => {
        this.setState({
            selectedFile: event.target.files[0],
            loaded: 0,
        })
    }

    onClickHandler = (config) => {
        const data = new FormData()
        data.append('file', this.state.selectedFile)
        data.append('config', JSON.stringify(config))

        axios.post("http://localhost:3000/upload", data)
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
            return <Persontable />
        } else {
            return <Coursetable />
        }
    }

    toggleClass = () => {
        this.setState({
            isVisible: !this.state.isVisible
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
                <div>
                    {this.switchSite()}
                </div>
                <Coursetable upload={this.onClickHandler} />
                <Persontable upload={this.onClickHandler} />
            </div>
        )
    }
}