pipeline {
	agent any
	stages {
		stage('Notify') {
			steps {
				echo "Start build #${env:BUILD_NUMBER}"
				slackSend channel: '#jenkins',
						  message: "${env:PROJECT_NAME} Develop Pipeline - #${env:BUILD_NUMBER} Started"
			}
		}

		stage('Build and analyze') {
			steps {
			pwsh ('''
					nuget restore "${env:workspace}/ADotNet.sln"
				''')
				bat "\"${tool 'MSBuild 17'}/msbuild.exe\" \"${env:workspace}/ADotNet.sln\" /clp:ErrorsOnly -t:build -property:Configuration=Release -property:Version=$buildVersion -property:PackageVersion=$buildVersion -property:AssemblyVersion=$buildVersion"
			}
		}
		
		stage('Push nuget packages') {
			steps {
				withCredentials([string(credentialsId: 'nuget-token', variable: 'TOKEN')]) {
					pwsh ('''
						Get-ChildItem -Path "${env:workspace}/" -Filter *.nupkg -Recurse | foreach {
							$file = $_
							write-host "Pushing $file to nuget server"
							nuget push "$file" $TOKEN -Source "https://nuget.sellercloud.com/v3/index.json"
						}
					''')
				}
			}
		}
	}

	post {
		success {	
			slackSend channel: '#jenkins',
					  color:   'good',
					  message: "${env:PROJECT_NAME} Develop Pipeline - #${env:BUILD_NUMBER} Succeeded. More: <${env:BUILD_URL}|Open>"
		}
		failure {
			slackSend channel: '#jenkins',
					  color:   'danger',
					  message: "${env:PROJECT_NAME} Develop Pipeline - #${env:BUILD_NUMBER} Failed. More: <${env:BUILD_URL}|Open>"
		}
	}

	environment {
		PROJECT_NAME = 'SellerCloud.ADotNet'
	}
}
