import React from 'react';
import './Filepicker.css';
import axios from 'axios';
import Fileinput from '../input/Fileinput';
import Dropdown from '../Dropdown/Dropdown';
import Fileinput2 from '../input/FIleinput2';

export default class Filepicker extends React.Component {
    constructor(props) {
        super(props);
        this.getPerson()
        this.getCursor()
        this.state = {
            selectFile: null,
            isVisible: true,
        }

    }
    person = [];
    getPerson() {
        var xhttp = new XMLHttpRequest();
        axios.get("http://192.168.0.94:8017/application/properties/person").then(res => {
            this.person = res.data
            this.person.forEach(option => {
                console.log(option)
            })

        }).catch(err => console.log(err))
    }
    curosr = [];
    getCursor() {
        var xhttp = new XMLHttpRequest();
        axios.get("http://192.168.0.94:8017/application/properties/cOurSe").then(res => {
            this.curosr = res.data
            this.curosr.forEach(option => {
                console.log(option)
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
    onClickHandler = (config) => {
        if (!this.state.selectFile) {
            alert(" bitte geben die die file ein")
            return
        }
        //var ex = this.state.selectFile.name.substring(this.state.selectFile.name.lastIndexOf('.'), this.state.selectFile.name.lenght)
        //data.append('fileExtension', ex)
        //data.append('base64String', window.btoa(this.state.selectFile));
        //data.append('config', JSON.stringify(window.btoa(config)))
        const data = new FormData()
        data.append('file', this.state.selectFile);
        data.append('config', JSON.stringify(config))
        axios.post("http://localhost:8000/upload", data, {
        })
            .then(res => {
            })
    }
    switchsite() {
        if (!this.state.isVisible) {
            return <Fileinput />
        } else {
            return <Fileinput2 />
        }
    }

    toggleClass = () => {
        this.setState({
            isVisible: !this.state.isVisible
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
                    {/* <Fileinput upload={this.onClickHandler} /> */}
                </div>
            </div>
        )
    }
}