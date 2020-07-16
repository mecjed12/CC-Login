import React from 'react';
import './Filepicker.css';
import axios from 'axios';
import Fileinput from '../input/Fileinput';
import Dropdown from '../Dropdown/Dropdown';

export default class Filepicker extends React.Component {
    constructor(props) {
        super(props);
        this.getPerson()
        this.getCursor()
        this.state = {
            selectFile: null,
            isVisible: true,
            persons: [],
            courses: [],
            name: null
        }
    }
    person = [];
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
    course = [];
    getCursor() {
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
            selectFile: event.target.files[0],
            loaded: 0,
        }
        );
    }
    onClickHandler = (properties) => {
        if (!this.state.selectFile) {
            alert(" bitte geben die die file ein")
            return
        }
        const data = new FormData()
        data.append('file', this.state.selectFile);
        data.append('properties', JSON.stringify(properties))
        console.log(properties)
        axios.post("http://192.168.0.94:8017/application/" + this.state.name, data, {
        })
        
            .then(res => { console.log(res)
            }).catch(err => console.log(err.response))
    }
    switchsite() {
        if (!this.state.isVisible) {
            if (this.state.persons.length > 0) {
                if (this.state.name !== "person")
                    this.setState({ name: "person" })
                return <Fileinput properties={this.state.persons} upload={this.onClickHandler} />
            }
        } else {
            if (this.state.courses.length > 0) {
                if (this.state.name !== "courses")
                    this.setState({ name: "courses" })
                return <Fileinput properties={this.state.courses} upload={this.onClickHandler} />
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
            <div className="file-container">
                <div className="upload-container">
                    <label>Bitte geben sie Ihre Datei ein!</label>
                    <input className="upload" type="file" name="file" onChange={this.onChangeHandler} />
                </div>
                <Dropdown toggleClass={this.toggleClass} />
                <div className="input-switch">
                    {this.switchsite()}
                </div>
            </div>
        )
    }
}