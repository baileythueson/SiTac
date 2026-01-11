# SiTac: Tactical Situational Awareness Suite

![Build Status](https://img.shields.io/github/actions/workflow/status/YOUR_USERNAME/SiTac/build.yml?label=Build&logo=github)
![Platform](https://img.shields.io/badge/Platform-Windows%20(WPF)-0078D7)
![Standard](https://img.shields.io/badge/Standard-Cursor%20on%20Target%20(CoT)-orange)

**SiTac** (Sim Tactical) is a distributed Command & Control (C2) system designed to visualize real-time telemetry from remote assets. Built on the **.NET 10** ecosystem, it implements the **Cursor on Target (CoT)** interoperability standard to maintain Common Operational Pictures (COP) across disparate nodes.

The suite simulates a "System of Systems" architecture, decoupling the hardware simulation from the visualization layer via UDP multicast networking.

---

## 🏗 Architecture

The solution follows a Clean Architecture approach, organized into a monorepo with shared kernel logic:

* **`SiTacLib` (Core):** A shared standard library containing the CoT data models, XML serialization logic, and networking primitives. Ensures strict schema validation between Sender and Receiver.
* **`SiTacSim` (The Edge):** A console-based asset simulator. It generates high-frequency telemetry (GPS, altitude, battery, velocity) for autonomous agents and broadcasts CoT events via UDP.
* **`SiTac` (The Dashboard):** A high-performance WPF application utilizing **MVVM**. It listens for incoming packets, deserializes the XML payload, and renders the assets on a geospatial display in real-time.

---

## 🎯 Key Features

### 1. Interoperability (Cursor on Target)
Implements the MIL-STD/Event Schema for CoT.
* **Event Generation:** Generates standard `a-f-A-M-F-Q` (Friendly/Air/Mil/Drone) atomic events.
* **Extensible Payloads:** Custom `<detail>` implementation for tracking extended metrics (Fuel, Signal Strength) while preserving schema compliance.

### 2. High-Performance Networking
* **UDP Multicast:** Utilizes `System.Net.Sockets` for fire-and-forget telemetry streams, mimicking low-bandwidth tactical radio environments.
* **Async/Await:** Heavy I/O operations are offloaded to background threads to ensure the UI remains responsive during high-traffic bursts.

### 3. Modern Desktop UI (WPF)
* **MVVM Pattern:** Strict separation of concerns using Data Binding and Commands.
* **Real-Time Visualization:** Dynamic map markers that interpolate position updates for smooth movement visualization.

---

## 🚀 Getting Started

### Prerequisites
* .NET 10.0 SDK
* Windows 10/11 (for WPF Client)

### Installation
You can download the latest binaries from the [Releases Page](https://github.com/baileythueson/SiTac/releases) or build from source:

1.  **Clone the repository**
    ```bash
    git clone [https://github.com/baileythueson/SiTac.git](https://github.com/YOUR_USERNAME/SiTac.git)
    ```

2.  **Build the Suite**
    ```bash
    dotnet build SiTac.sln -c Release
    ```

3.  **Run the Simulation**
    * Start `SiTac.exe` (The Dashboard) first to open the listener.
    * Start `SiTacSim.exe` (The Simulator) to begin broadcasting telemetry.

---

## 🛠 Tech Stack

| Category | Technology | Usage |
| :--- | :--- | :--- |
| **Language** | C# / .NET 10 | Core Application Logic |
| **UI Framework** | WPF (Windows Presentation Foundation) | Mission Dashboard |
| **Architecture** | MVVM (Model-View-ViewModel) | UI Decoupling |
| **Networking** | UDP Sockets | Data Transport Layer |
| **Data Format** | XML (Cursor on Target) | Serialization |
| **CI/CD** | GitHub Actions | Automated Build & Release |

---

## 📜 License
Distributed under the MIT License. See `LICENSE` for more information.
